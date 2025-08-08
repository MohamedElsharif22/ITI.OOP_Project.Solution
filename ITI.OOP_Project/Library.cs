using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.OOP_Project
{
    internal class Library
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public Library(List<Book> books, List<Member> members)
        {
            Books = books ?? new List<Book>();
            Members = members ?? new List<Member>();
        }
        public void AddMember(Member member)
        { 
            if(member!=null)
            {
                foreach(var m in Members)
                {
                    if(m.Id== member.Id)
                    { 
                        Console.WriteLine("member is Already in Memberlist");      
                        return;
                    }
                }
                Members.Add(member);

            }
            else
            {
                Members.Add(member);
            }
        }
        public void removeMember(int memberId)
        {
            int v = 0;
            foreach (Member m in Members)
            {
                if (m.Id == memberId)
                {
                    Members.Remove(m);
                    v=1; break;
                }
            }
            if(v == 0)
            {
                Console.WriteLine("member is Already not found");
            }
          
        }
    }
}
