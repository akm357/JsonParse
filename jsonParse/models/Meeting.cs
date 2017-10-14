/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 14/10/2017
 * Time: 5:22 PM
 * 
 */
 
using System;

namespace jsonParse.Models
{
  public class Meeting
  {
    public int? id {get;set;}
    public string name {get;set;}
    public string state {get;set;}
    public DateTime? Date {get;set;}
    public Race[] races {get;set;}
  }
  
  public class MeetingContainer
  {
    public Meeting Meeting {get;set;}
  }
}