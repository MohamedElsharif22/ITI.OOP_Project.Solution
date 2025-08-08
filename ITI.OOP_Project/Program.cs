using System.ComponentModel.Design.Serialization;

namespace ITI.OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library l=new Library();
            Member m = new Member(13, "mahmoud");
            l.AddMember(m);
            Member mm = new Member(14, "ashraf");
            l.AddMember(mm);
            Member mmm = new Member(15, "Ghazaly");
            l.AddMember(mmm);
            Member mmmm = new Member(15, "Ghazaly");
            l.AddMember(mmmm);
            l.removeMember(14);
            l.removeMember(17);
            foreach (Member member in l.Members)
            {
                Console.WriteLine($"{member.Name}  ==> {member.Id}");
            }
        }
    }
}
