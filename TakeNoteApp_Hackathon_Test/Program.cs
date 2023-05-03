using System.Collections.Generic;

namespace TakeNoteApp_Hackathon_Test
{
    internal class Program
    {
        class Notes
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }

        }

        class NotesDetails
        {
            List<Notes> notes;
            public int Notes_Count = 0;

            public NotesDetails() {
                notes = new List<Notes>();
            }
           
            public void Add_Notes()
            {
                int id = ++Notes_Count;

                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                DateTime date = DateTime.Now;

                notes.Add(new Notes() {Id = id, Title = title, Description = description, Date = date});
              
                Console.WriteLine("Note Added Successfully");
                Console.WriteLine();
            }
            public Notes Get_Notes(int id)
            {
                foreach (Notes n in notes)
                {
                    if (n.Id == id)
                        return n;
                }
                return null;
            }
            public List<Notes> Get_All_Notes()
            {
                return notes;
            }

            public bool Delete_Notes(int id)
            {
                foreach (Notes n in notes)
                {
                    if (n.Id == id)
                    {
                        notes.Remove(n);
                        return true;
                    }
                }
                return false;
            }

            public void Update_Notes(int id)
            {
                foreach (Notes n in notes)
                {
                    if (n.Id == id)
                    {
                        Console.WriteLine("Enter updated Notes Title");
                        n.Title = Console.ReadLine();
                        Console.WriteLine("Enter updated Notes Description");
                        n.Description = Console.ReadLine();
                        n.Date = DateTime.Now;

                        Console.WriteLine("Notes Updated Successfully");
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            NotesDetails details = new NotesDetails();
            
            while(true) 
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Add Notes");
                Console.WriteLine("2. Get Notes By Id");
                Console.WriteLine("3. Get All Notes");
                Console.WriteLine("4. Delete Notes By Id");
                Console.WriteLine("5. Update Notes By Id");
                int choice = 0;
                try
                {
                    Console.WriteLine("Enter Your choice: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                }catch(FormatException)
                {
                    Console.WriteLine("Enter only Numbers");
                }
                Console.WriteLine("---------------------------------------------------------");
                switch (choice)
                {
                    case 1:
                        {
                            details.Add_Notes();
                            break;
                        }
                    case 2:
                        {
                            int id = 0;
                            try
                            {
                                Console.WriteLine("Enter Notes Id");
                                id = Convert.ToInt16(Console.ReadLine());
                            }catch (FormatException)
                            {
                                Console.WriteLine("Enter the ID(Integer Only)");
                            }
                            Notes? n = details.Get_Notes(id);
                            if (n == null)
                            {
                                Console.WriteLine("Notes not exists");
                            }
                            else
                            {
                                Console.WriteLine($"Notes Details of id-{n.Id} :");
                                Console.WriteLine($"Title : {n.Title}\nDescription : {n.Description}\nDate : {n.Date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ID\tTitle\t\tDescription\t\tDate");
                            foreach (var n in details.Get_All_Notes())
                            {
                                Console.WriteLine($"{n.Id}\t{n.Title}\t{n.Description}\t{n.Date}");
                            }
                            Console.WriteLine();
                            Console.Write("Total Notes = ");
                            Console.Write($"{details.Notes_Count}");
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            int id = 0;
                            try
                            {
                                Console.WriteLine("Enter Notes Id");
                                id = Convert.ToInt16(Console.ReadLine());
                            }catch(FormatException)
                            {
                                Console.WriteLine("Enter the ID(Integer Only)");
                            }
                            if (details.Delete_Notes(id))
                            {
                                Console.WriteLine("Notes Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Notes not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            int id = 0;
                            try
                            {
                                Console.WriteLine("Enter Notes Id");
                                id = Convert.ToInt16(Console.ReadLine());
                            } catch (FormatException){
                                Console.WriteLine("Enter the ID(Integer Only)");
                            }
                            details.Update_Notes(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
                
            } 
        }
    }
}