/*
 * Created by SharpDevelop.
 * User: aaron
 * Date: 14/10/2017
 * Time: 5:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace jsonParse.Models
{
  public class Race
  {
    public int? id { get; set; }
    public int? racenumber { get; set; }
    public string racename { get; set; }
    public DateTime? starttime { get; set; }
    public DateTime? endtime { get; set; }
  }
}