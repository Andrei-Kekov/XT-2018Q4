"use strict"

var page = +pageNumber.innerHTML,
	delay = 5000,
	secondsLeft = delay / 1000,
	ticking = true,
	timer = setTimeout(Tick, 1000);

countdown.innerHTML = secondsLeft;

countdown.onclick = function()
{
	if (ticking)
	{
		clearTimeout(timer);
		ticking = false;
	}
	else
	{
		timer = setTimeout(Tick, 1000);
		ticking = true;
	}
}

if (page > 1)
{
	window.onkeydown = function(event)
	{
		if (event.which == 90)
		{
			Previous();
		}
	}
}	

function Tick()
{
	secondsLeft--;
	countdown.innerHTML = secondsLeft;

	if (!secondsLeft)
	{
		Next();
	}
	else
	{
		timer = setTimeout(Tick, 1000);
	}
}

function Previous()
{
	if (page == 2)
	{
		document.location.href = "index.htm";
	}
	else
	{
		document.location.href = "page" + (page - 1) + ".htm";
	}
}

function Next()
{
	if (page < 3)
	{
		document.location.href = "page" + (page + 1) + ".htm";
	}
	else
	{
		var reply = confirm("This is the final page. Would you like to return to the index page?");
		
		if (reply)
		{
			document.location.href = "index.htm";
		}
		else
		{
			window.close();
		}
	}
}