using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class DataManager : IDataManager
    {
        private static List<Claim> Claims;
        private static List<Member> Members;
        public DataManager()
        {
            Claims = new List<Claim>();
            Members = new List<Member>();
            SetupClaims();
            SetupMembers();
        }
        private void SetupClaims()
        {
            Claims = new List<Claim>();
            ReadCsvFileClaim("Claim.csv");
        }
        private void SetupMembers()
        {
            Members = new List<Member>();
            ReadCsvFileMember("Member.csv");

        }
        public List<Claim> GetClaims()
        {
            return Claims;
        }

        public List<Member> GetMembers()
        {
            return Members;
        }

        //Get Members
        static void ReadCsvFileMember(string filename)
        {
            TextReader textReader = File.OpenText(filename);
            bool keepReading = true;
            bool headerNotRead = true;
            while(keepReading)
           {
                string txt = textReader.ReadLine();
                if (txt == null)
                    keepReading = false;
                else if(headerNotRead)
                {
                    headerNotRead = false;
                }
                else
                {
                    var parts = txt.Split(",".ToCharArray());
                    var mem = new Member()
                    {
                        MemberId = Int32.Parse(parts[0].ToString()),
                        EnrollmentDate = DateTime.Parse(parts[1].ToString()),
                        FirstName = parts[2].ToString(),
                        LastName = parts[3].ToString()
                    };
                    Members.Add(mem);
                }

            }
            textReader.Close();          
        }

        //Get Claims
        static void ReadCsvFileClaim(string filename)
        {
            TextReader textReader = File.OpenText(filename);
            bool keepReading = true;
            bool headerNotRead = true;
            while (keepReading)
            {
                string txt = textReader.ReadLine();
                if (txt == null)
                    keepReading = false;
                else if (headerNotRead)
                {
                    headerNotRead = false;
                }
                else
                {
                    var parts = txt.Split(",".ToCharArray());
                    var claim = new Claim()
                    {
                        MemberId = Int32.Parse(parts[0].ToString()),
                         ClaimDate =  DateTime.Parse(parts[1].ToString()),
                         ClaimAmount= float.Parse(parts[2].ToString())
                    };
                    Claims.Add(claim);
                }

            }
            textReader.Close();
        }
    }
}
