using System;

//class that checks if the wokr shift that it gets is valid in terms of hours and time.
public class Shift
{
	private DateTime shiftdate { get; }
	private string shiftstart { get; set; }
	private string shiftend { get; set; }
	private TimeSpan duration { get;  set; }
	public Shift(DateTime date, string start, string end)
	{
		shiftdate = date;
		shiftstart = start;
		shiftend = end;
	}

	//Method that sees if all the requirements for the work shift are fulfilled, informs user if they are or if they aren't
	public String TestShift()
	{
		//Parsing the starting time string to TimeSpan and checking that it isn't below 0
		try
		{
			TimeSpan start = TimeSpan.Parse(shiftstart);
			if(start < TimeSpan.Parse("0"))
			{
				return "Starting time can't be negative!";
			}
		}
		catch (FormatException)
		{
			return "Starting time was in wrong format.";
		}
		catch (OverflowException)
		{
			return "Starting time wasn't on the clock (notice that 24:00 is 00:00)";
		}

		//Parsing the ending time string to TimeSpan and checking that it isn't below 0
		try
		{
			TimeSpan end = TimeSpan.Parse(shiftend);
			if (end < TimeSpan.Parse("0"))
			{
				return "Ending time can't be negative!";
			}
		}
		catch (FormatException)
		{
			return "Ending time was in wrong format.";
		}
		catch (OverflowException)
		{
			return "Ending time wasn't on the clock (notice that 24:00 is 00:00)";
		}

		
		duration = TimeSpan.Parse(shiftend) - TimeSpan.Parse(shiftstart);

		//Check to make sure the duration of the work shift isn't over 16 hours or that the shift starting time and ending time are chronological
		if (TimeSpan.Compare(TimeSpan.Parse(shiftstart), TimeSpan.Parse(shiftend)) >= 0)
		{
			return "Finishing hour has to be later than starting hour!\n";
		}

		else if(duration.TotalHours > 16)
		{
			return "Shift is too long! (" + duration.TotalHours + " hours)";
		}

		//Returns information about the shift to the user
		else
		{
			return "Shift is valid. Shift is on " + shiftdate.Day + "." + shiftdate.Month + "." + shiftdate.Year + ". Hours are from " + shiftstart + " to " + shiftend + " and the duration is " + Math.Round(duration.TotalHours,2) + " hours.";
		}
		
	}

	
}
