function DateFunctions()
{
	this.twoDigitYearCenturyWindow = 50;

	this.adjustTwoDigitYear = function(y)
	{
		if (y < 100) 
		{
			return y + ((y >= this.twoDigitYearCenturyWindow) ? 1900 : 2000);
		}
		else
		{
			return y;
		}
	}
		
	this.now = function()
	{
		return new Date();
	}

	this.isTime = function(aString)
	{
		var
			a = aString.split(":"), h, m, s;
				
		if (a.length < 2 || a.length > 3) 
		{
			return false;
		}
		else
		{
			if (!isInteger(a[0])) return false;
			if (!isInteger(a[1])) return false;
			
			if (a.length == 3)
			{
				if (!isInteger(a[2])) return false;
			}
				
			h = parseInt(a[0], 10);
			m = parseInt(a[1], 10);
			
			if (a.length == 3)
			{
				s = parseInt(a[2], 10);
			}

			if (h < 0 || h > 24) return false;
			if (m < 0 || m > 59) return false;
			
			if (a.length == 3)
			{
				if (s < 0 || s > 59) return false;
			}
				
			return true;
		}
	}
	
	this.isDate = function(aString)
	{
		var
			a = aString.split("/"), d, m, y;
				
		if (a.length != 3) 
		{
			return false;
		}
		else
		{
			if (!isInteger(a[0])) return false;
			if (!isInteger(a[1])) return false;
			if (!isInteger(a[2])) return false;						
				
			d = parseInt(a[0], 10);
			m = parseInt(a[1], 10);
			y = parseInt(a[2], 10);

			y = this.adjustTwoDigitYear(y);
				
			if (m < 1 || m > 12) return false;
			if (d < 1 || d > this.daysInMonth(m, y)) return false;
				
			return true;
		}
	}
	
	this.daysInMonth = function(month, year)
	{
		switch(month)
		{
			case 1:
			case 3:
			case 5:
			case 7:
			case 8:
			case 10:
			case 12:
				return 31;
			case 2: 
				return this.isLeapYear(year) ? 29 : 28;
			default:
				return 30;
		}
	}
		
	this.isLeapYear = function(year)
	{
		return (((year % 4) == 0) && ((year % 100)!= 0) || ((year % 400) == 0));
	}	
	
	this.stringToDate = function(aString, time)
	{
		if (this.isDate(aString))
		{
			var
				a = aString.split("/");
				a[2] = this.adjustTwoDigitYear(parseInt(a[2], 10));
				a[1] = parseInt(a[1], 10) - 1;
				
			if (arguments.length > 1)
			{
				switch(time)
				{
					case 1: 
						return new Date(a[2], a[1], a[0], 0, 0, 0);
					case 2: 
						return new Date(a[2], a[1], a[0], 23, 59, 59);
					default:
					  t = this.now();
						return new Date(a[2], a[1], a[0], t.getHours(), t.getMinutes(), t.getSeconds());
				}
			}
			else
			{
				var t = this.now();
				return new Date(a[2], a[1], a[0], t.getHours(), t.getMinutes(), t.getSeconds());
			}
		}
		else
		{
			return null;
		}
	}
	
	this.dateToUniversalDate = function(aDate, time)
	{
		if (aDate == null)
		{
			return null;
		}
		else
		{
			var 
				d = aDate.getDate(), m = aDate.getMonth() + 1, y = aDate.getYear(), 
				h = aDate.getHours(), n = aDate.getMinutes(), s = aDate.getSeconds();
			
			if (d < 10) d = "0" + d;
			if (m < 10) m = "0" + m;
			if (h < 10) h = "0" + h;
			if (n < 10) n = "0" + n;
			if (s < 10) s = "0" + s;
			
			return y + m + d + " " + h + ":" + n + ":" + s;
		}
	}
	
	this.dateToString = function(aDate, showTime)
	{
		if (aDate == null)
		{
			return null;
		}
		else
		{
			var 
				d = aDate.getDate(), m = aDate.getMonth() + 1, y = aDate.getYear(), 
				h = aDate.getHours(), n = aDate.getMinutes(), s = aDate.getSeconds();
			
			if (d < 10) d = "0" + d;
			if (m < 10) m = "0" + m;
			if (h < 10) h = "0" + h;
			if (n < 10) n = "0" + n;
			if (s < 10) s = "0" + s;
			
			var
				r = d + "/" + m + "/" + y;
				
			if (arguments.length > 1 && showTime)
			{
				r += " " + h + ":" + n + ":" + s;
			}
			
			return r;
		}
	}
}

dateFunctions = new DateFunctions();