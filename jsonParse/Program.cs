/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 14/10/2017
 * Time: 11:01 AM
 * 
 */
using System;
using System.Data;
using System.IO;
using System.Web.Script.Serialization;

using jsonParse.Models;
namespace jsonParse
{
  /// <summary>
  /// Exercise Scenario
  /// Considerations and assumptions
  /// --the file SampleData.json will be in the application root
  /// --nulls need not be handled
  /// --only a single meeting object in a result
  /// --datatable is a sufficent data structure for in memory database requirement
  /// --no third party libraries
  /// </summary>
  class SkyJsonParse
  {
    public static Database Db;
    public const string filePath = "SampleData.json";
    
    /// <summary>
    /// initalise the in-memory database
    /// </summary>
    static SkyJsonParse()
    {
      Db = new Database();
    }

    /// <summary>
    /// Program entry point
    /// </summary>
    public static void Main(string[] args)
    {
      
      try {
        //read in SampleData.json
        var json = File.ReadAllText(filePath);
        
        //proccess JSON
        var meeting = new JavaScriptSerializer()
          .Deserialize<MeetingContainer>(json)
          .Meeting;
        
        //write meeting(s) to database
        var mRow = Db.tblMeetings.NewRow();
        mRow["pkeyMeetingId"] = meeting.id;
        mRow["fldName"] = meeting.name;
        mRow["fldState"] = meeting.state;
        mRow["fldDate"] = meeting.Date;
        Db.tblMeetings.Rows.Add( mRow );
        
        //write races to database
        foreach (var r in meeting.races) {
          var rRow = Db.tblRaces.NewRow();
          rRow["pkeyRaceId"] = r.id;
          rRow["fkeyMeetingId"] = meeting.id;
          rRow["fldRaceNumber"] = r.racenumber;
          rRow["fldRaceName"] = r.racename;
          rRow["fldStartTime"] = r.starttime;
          rRow["fldEndTime"] = r.endtime;
          Db.tblRaces.Rows.Add(rRow);
        }
        
        Console.Out.WriteLine(string.Format("{0} successfully read, processed and written to database.", filePath));
      }
      
      catch (Exception ex)
      {
        Console.Out.WriteLine("Application Error");
        Console.Out.WriteLine(ex);
        
      }
      
      Console.Write("Press any key to continue . . . ");
      Console.ReadKey(true);
    }
    
  }
}