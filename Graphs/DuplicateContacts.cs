namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DuplicateContacts : ISolution
    {
        private List<Contact> contacts;

        private Dictionary<Contact, HashSet<Contact>> contactAdjList = new Dictionary<Contact, HashSet<Contact>>();

        private Dictionary<string, HashSet<Contact>> nameAdjList = new Dictionary<string, HashSet<Contact>>();

        private Dictionary<string, HashSet<Contact>> phoneAdjList = new Dictionary<string, HashSet<Contact>>();

        private Dictionary<string, HashSet<Contact>> emailAdjList = new Dictionary<string, HashSet<Contact>>();

        public DuplicateContacts(List<Contact> contacts)
        {
            // Remove dups which have all props matching
            this.contacts = contacts.GroupBy(x => new { x.Name, x.Email, x.Phone }).Select(x => x.First()).ToList();
        }

        public void Run()
        {
            // Update adjacency lists per contact property
            foreach (var contact in contacts)
            {
                this.AddOrUpdate(nameAdjList, contact.Name, contact);
                this.AddOrUpdate(phoneAdjList, contact.Phone, contact);
                this.AddOrUpdate(emailAdjList, contact.Email, contact);
            }

            // Update adjaceny list for all contacts. Add edge if any of the property matches
            foreach (var contact in contacts)
            {
                this.CreateEdge(nameAdjList, contact.Name, contact);
                this.CreateEdge(phoneAdjList, contact.Phone, contact);
                this.CreateEdge(emailAdjList, contact.Email, contact);
            }

            // Now we have a graph with connected components. Get all of them
            var duplicates = this.GetConnectedComponents();

            foreach (var dup in duplicates)
            {
                Console.WriteLine("Duplicate List: {0}", string.Join(",", dup));
            }
        }

        private List<List<Contact>> GetConnectedComponents()
        {
            List<List<Contact>> components = new List<List<Contact>>();
            HashSet<Contact> visited = new HashSet<Contact>();

            foreach (Contact contact in this.contacts)
            {
                if (!visited.Contains(contact))
                {
                    List<Contact> component = this.GetComponent(contact, visited);
                    components.Add(component);
                }
            }

            return components;
        }

        // Do Breadth first traversal
        private List<Contact> GetComponent(Contact contact, HashSet<Contact> seen)
        {
            HashSet<Contact> visited = new HashSet<Contact>();

            Queue<Contact> queue = new Queue<Contact>();
            queue.Enqueue(contact);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                seen.Add(node);

                if (!visited.Contains(node))
                {
                    visited.Add(node);

                    foreach (var neighbor in this.contactAdjList[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return visited.ToList();
        }

        private void CreateEdge(Dictionary<string, HashSet<Contact>> dict, string key, Contact contact)
        {
            // Get all neighbors, except self
            var neighbors = new HashSet<Contact>(dict[key].Where(x => x != contact));

            // Update the contact adjaceny list 
            if (!contactAdjList.ContainsKey(contact))
            {
                contactAdjList.Add(contact, neighbors);
            }
            else
            {
                foreach (var neighbor in neighbors)
                {
                    contactAdjList[contact].Add(neighbor);
                }
            }
        }

        private void AddOrUpdate(Dictionary<string, HashSet<Contact>> dict, string key, Contact contact)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new HashSet<Contact> { contact });
            }
            else
            {
                dict[key].Add(contact);
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            string s = string.Format("{0}:{1}:{2}", this.Name, this.Phone, this.Email);
            return s;
        }
    }
}