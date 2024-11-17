/*Your monthly phone bill has just arrived, and its unexpectedly large. You decide to verify the amount by recalculating the bill based on your phone call logs
and the phone company's charges. The logs are given as a string S consisting of N lines separated by end-of-line characters (ASCII code 10).
Each line describes one phone call using the following format: "hh:mm:ss,nnn-nnn-nnn", where "hh:mm:ss" denotes the duration of the call
(in "hh" hours, "mm" minutes and "ss" seconds) and "nnn-nnn-nnn" denotes the 9 digit phone number of the recipient (with no leading zeros).

Each call is billed separately. The billing rules are as follows:
If the call was shorter than 5 minutes, then you pay 3 cents for every started second of the call (e.g. for duration "00:01:07" you pay 67*3=201 cents).
If the call was at least 5 minutes long, then you pay 150 cents for every started minute of the call
(e.g. for duration "00:05:00" you pay 5*150=750 cents and for duration "00:05:01" you pay 6*150=900 cents).
All calls to the phone number that has the longest total duration of calls are free. In the case of a tie, if more than one phone number shares the longest
total duration, the promotion is applied only to the phone number whose numerical value is the smallest among these phone numbers.

Write a C# function: class Solution { public int solution(string S); } that, given a string S describing phone call logs,
returns the amount of money you have to pay in cents.
For example, given string S with N = 3 lines:
"00:01:07,400-234-090
00:05:01,701-080-080
00:05:00,400-234-090"
the function should return 900 (the total duration for number 400-234-090 is 6 minutes 7 seconds,
and the total duration for number 701-080-080 is 5 minutes 1 second; therefore, the free promotion applies to the former phone number).

Assume that:
N is an integer within the range [1..100];
every phone number follows the format "nnn-nnn-nnn" strictly; there are no leading zeros;
the duration of every call follows the format "hh:mm:ss" strictly (00<=hh<=99, 00<=mm, ss<= 59);
each line follows the format "hh:mm:ss,nnn-nnn-nnn" strictly; there are no empty lines and spaces.*/

using System;
using System.Collections.Generic;

class Solution {
    public int solution(string S) {
    string[] logs = S.Split('\n');
    
    Dictionary<string, int> numTime = new Dictionary<string, int>();
    foreach(string row in logs) {
        string[] details = row.Split(',');
        int hours = int.Parse(details[0].Substring(0,2)) * 3600;
        int minutes = int.Parse(details[0].Substring(3, 2)) * 60;
        int seconds = int.Parse(details[0].Substring(6, 2));
        int totalTime = hours + minutes + seconds;

        if (numTime.ContainsKey(details[1])) {
            totalTime += numTime[details[1]];
            numTime[details[1]] = totalTime;
        } else
            numTime[details[1]] = totalTime;
    }

    int maxTime = 0;
    int maxNumVal = 0;
    string maxNum = "";
    foreach(KeyValuePair<string, int> entry in numTime) {
        int time = entry.Value;
        if (time > maxTime) {
            maxNum = entry.Key;
            maxNumVal = int.Parse(entry.Key.Replace("-", ""));
            maxTime = time;
        } else

        if (time == maxTime) {
            if (int.Parse(entry.Key.Replace("-", "")) < maxNumVal ) {
                maxNum = entry.Key;
                maxNumVal = int.Parse(entry.Key.Replace("-", ""));
            }
        }
    }

    int total = 0;
    foreach (KeyValuePair<string, int> entry in numTime) {
        if (entry.Key == maxNum) continue;
        if (entry.Value > 300) {
            total += ((entry.Value / 60) * 150);
            if (entry.Value % 60 != 0) total += 150;
        } else
            total += (entry.Value * 3);
    }
    
    return total;
    }
}