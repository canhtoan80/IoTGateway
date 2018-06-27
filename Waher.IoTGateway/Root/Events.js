﻿function CheckEvents(TabID)
{
    var NeedsReload = false;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function ()
    {
        if (xhttp.readyState == 4)
        {
            if (xhttp.status == 200)
            {
                if (NeedsReload)
                {
                    delete xhttp;
                    window.location.reload(false);
                    return;
                }

                var Events;
                var Event;
                var i, c;

                try
                {
                    try
                    {
                        Events = JSON.parse(xhttp.responseText);
                    }
                    catch (e)
                    {
                        throw "Invalid JSON received: " + xhttp.responseText;
                    }

                    if (Events != null)
                    {
                        c = Events.length;
                        for (i = 0; i < c; i++)
                        {
                            Event = Events[i];
                            if (Event.type.match(/^[a-zA-Z0-9]+$/g))
                                eval(Event.type + "(Event.data)");
                        }
                    }
                }
                finally
                {
                    if (EventCheckingEnabled)
                    {
                        xhttp.open("POST", "/ClientEvents", true);
                        xhttp.setRequestHeader("Content-Type", "text/plain");
                        xhttp.setRequestHeader("X-TabID", TabID);
                        xhttp.send(window.location.href);
                    }
                    else
                        delete xhttp;
                }
            }
            else
            {
                ShowError(xhttp);

                if (EventCheckingEnabled)
                {
                    window.setTimeout(function ()
                    {
                        NeedsReload = true;
                        xhttp.open("POST", "/ClientEvents", true);
                        xhttp.setRequestHeader("Content-Type", "text/plain");
                        xhttp.setRequestHeader("X-TabID", TabID);
                        xhttp.send(window.location.href);
                    }, 5000);
                }
                else
                    delete xhttp;
            }
        };
    }

    EventCheckingEnabled = true;

    xhttp.open("POST", "/ClientEvents", true);
    xhttp.setRequestHeader("Content-Type", "text/plain");
    xhttp.setRequestHeader("X-TabID", TabID);
    xhttp.send(window.location.href);
}

function CloseEvents()
{
    EventCheckingEnabled = false;
}

function ShowError(xhttp)
{
    if (xhttp.responseText.length > 0)
        window.alert(xhttp.responseText);
}

function CreateGUID()
{
    function Segment()
    {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
    }

    return Segment() + Segment() + '-' + Segment() + '-' + Segment() + '-' + Segment() + '-' + Segment() + Segment() + Segment();
}

function NOP(Data)
{
}

function Reload(Data)
{
    window.location.reload(false);
}

function EndsWith(String, Suffix)
{
    var c = String.length;
    var d = Suffix.lenght;

    if (c < d)
        return false;

    return String.substring(c - d, c) === Suffix;
}

var TabID;
var EventCheckingEnabled = true;

try
{
    if (window.name.length == 36)
        TabID = window.name;
    else
        TabID = window.name = CreateGUID();
}
catch (e)
{
    TabID = CreateGUID();
}

CheckEvents(TabID);
