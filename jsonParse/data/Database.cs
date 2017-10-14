/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 14/10/2017
 * Time: 12:53 PM
 * 
 */
using System;
using System.Data;
using System.Linq;

namespace jsonParse
{
  
  /// <summary>
  /// In memory database implementation
  /// </summary>
  public class Database
  {
    
    public DataTable tblMeetings;
    public DataTable tblRaces;
    
    /// <summary>
    /// Construct Database and tables
    /// </summary>
    public Database()
    {
      //create tables
      tblMeetings = new DataTable("tblMeetings");
      tblRaces    = new DataTable("tblRaces");
      
      //create columns
      tblMeetings.Columns.AddRange(new []{new DataColumn("pkeyMeetingId",typeof(int)),
                                     new DataColumn(      "fldName"),
                                     new DataColumn(      "fldState"),
                                     new DataColumn(      "fldDate", typeof(DateTime))});
      
      tblRaces.Columns.AddRange(new []{new DataColumn("pkeyRaceId",typeof(int)),
                                  new DataColumn("fkeyMeetingId", typeof(int)),
                                  new DataColumn("fldRaceNumber"),
                                  new DataColumn("fldRaceName"),
                                  new DataColumn("fldStartTime", typeof(DateTime)),
                                  new DataColumn("fldEndTime", typeof(DateTime))});
    }
    
  }

}