using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeDocumentationTool
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class DocumentAttribute : Attribute
    {
        public DocumentAttribute() { }

        public DocumentAttribute(string description)
        {
            Description = description;
        }

        public DocumentAttribute(string description, string input = "", string output = "")
        {
            Description = description;
            Input = input;
            Output = output;
        }

        public string Description { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }

        [Document(Description = "Female software developers in Genesys")]
        public class FemaleDevelopers
        {
            [Document(
                Description = "This assigns value to the Name field",
                Input = "This is a field which is the Name of female software developers and the data type is  string"
            )]
            public FemaleDevelopers(string name)
            {
                Name = name;
            }

            [Document(
                Description = "This is a property, it sets and gets  the names of the software developers"
            )]
            public string Name { get; set; }

            [Document(Description = "This is also a property, it sets and gets  their Contacts")]
            public string Contact { get; set; }

            [Document(
                Description = "This describes what happens in each department",
                Input = "It takes a string name",
                Output = "It brings out the output"
            )]
            public string SampleCode(string name)
            {
                return name;
            }

            [Document(Description = "This contains enumerable for the different departments")]
            public enum Departments
            {
                OS,
                Networking,
                Finance
            }
        }
    }
}
