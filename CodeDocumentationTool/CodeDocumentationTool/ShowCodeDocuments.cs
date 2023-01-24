using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CodeDocumentationTool
{
    public static class ShowCodeDocuments
    {
        public readonly static StringBuilder FileData = new StringBuilder();
        public static List<DocumentAttribute> @DocumentAttribute { get; set; } =
            new List<DocumentAttribute>();

        public static void GetDocs()
        {
            var assemblyData = Assembly.GetExecutingAssembly();

            Console.WriteLine($"\nAssembly:{assemblyData}\n");
            FileData.AppendLine($"\nAssembly:{assemblyData}\n");

            var typeData = assemblyData.GetTypes();

            foreach (Type type in typeData)
            {
                var attributeData = type.GetCustomAttributes(typeof(DocumentAttribute), true);

                if (attributeData.Length > 0)
                {
                    if (type.IsClass)
                    {
                        Console.WriteLine($"\tClass: {type.Name}");
                        FileData.AppendLine($"\tClass:{type.Name}");
                        Console.WriteLine(
                            $"\tDescription: {((DocumentAttribute)attributeData[0]).Description}\n"
                        );
                        FileData.AppendLine(
                            $"\tDescription:{((DocumentAttribute)attributeData[0]).Description}"
                        );
                        DocumentAttribute.Add(
                            new DocumentAttribute
                            {
                                Output = type.Name,
                                Description = ((DocumentAttribute)attributeData[0]).Description
                            }
                        );

                        foreach (ConstructorInfo constructor in type.GetConstructors())
                        {
                            var constructorAttributes = constructor.GetCustomAttributes(
                                typeof(DocumentAttribute),
                                true
                            );
                            if (constructorAttributes.Length > 0)
                            {
                                Console.WriteLine($"\tConstructor: {constructor.Name}");
                                FileData.AppendLine($"\tConstructor: {constructor.Name}");

                                Console.WriteLine(
                                    $"\t\tDescription:{((DocumentAttribute)constructorAttributes[0]).Description}"
                                );
                                FileData.AppendLine(
                                    $"\t\tDescription:{((DocumentAttribute)constructorAttributes[0]).Description}"
                                );
                                Console.WriteLine(
                                    $"\t\tInput:{((DocumentAttribute)constructorAttributes[0]).Input}\n"
                                );
                                FileData.AppendLine(
                                    $"\t\tInput:{((DocumentAttribute)constructorAttributes[0]).Input}\n"
                                );

                                DocumentAttribute.Add(
                                    new DocumentAttribute
                                    {
                                        Output = constructor.Name,
                                        Description = (
                                            (DocumentAttribute)constructorAttributes[0]
                                        ).Description,
                                        Input = ((DocumentAttribute)constructorAttributes[0]).Input
                                    }
                                );
                            }
                        }

                        foreach (MethodInfo method in type.GetMethods())
                        {
                            var methodAttributes = method.GetCustomAttributes(
                                typeof(DocumentAttribute),
                                true
                            );
                            if (methodAttributes.Length > 0)
                            {
                                Console.WriteLine($"\tMethod:{method.Name}\n");
                                FileData.AppendLine($"\tMethod:{method.Name}\n");
                                Console.WriteLine(
                                    $"\t\tDescription: {((DocumentAttribute)methodAttributes[0]).Description}"
                                );
                                FileData.AppendLine(
                                    $"\t\tDescription: {((DocumentAttribute)methodAttributes[0]).Description}"
                                );
                                Console.WriteLine(
                                    $"\t\tInput:{((DocumentAttribute)methodAttributes[0]).Input}"
                                );
                                FileData.AppendLine(
                                    $"\t\tInput:{((DocumentAttribute)methodAttributes[0]).Input}"
                                );

                                Console.WriteLine(
                                    $"\t\tOutput:{((DocumentAttribute)methodAttributes[0]).Output}\n"
                                );
                                FileData.AppendLine(
                                    ((DocumentAttribute)methodAttributes[0]).Output
                                );
                                DocumentAttribute.Add(
                                    new DocumentAttribute
                                    {
                                        Output = method.Name,
                                        Description = (
                                            (DocumentAttribute)methodAttributes[0]
                                        ).Description,
                                        Input = ((DocumentAttribute)methodAttributes[0]).Input
                                    }
                                );
                            }
                        }

                        foreach (PropertyInfo property in type.GetProperties())
                        {
                            var propertyAttributes = property.GetCustomAttributes(
                                typeof(DocumentAttribute),
                                true
                            );
                            if (propertyAttributes.Length > 0)
                            {
                                Console.WriteLine($"\tProperty:{property.Name}");
                                FileData.AppendLine($"\tProperty:{property.Name}");
                                Console.WriteLine(
                                    $"\t\tDescription:{((DocumentAttribute)propertyAttributes[0]).Description}"
                                );
                                FileData.AppendLine(
                                    $"\t\tDescription:{((DocumentAttribute)propertyAttributes[0]).Description}"
                                );

                                Console.WriteLine(
                                    $"\t\tOutput:{((DocumentAttribute)propertyAttributes[0]).Output}\n"
                                );
                                FileData.AppendLine(
                                    $"\t\tOutput:{((DocumentAttribute)propertyAttributes[0]).Output}\n"
                                );

                                DocumentAttribute.Add(
                                    new DocumentAttribute
                                    {
                                        Output = property.Name,
                                        Description = (
                                            (DocumentAttribute)propertyAttributes[0]
                                        ).Description
                                    }
                                );
                            }
                        }
                    }

                    if (type.IsEnum)
                    {
                        Console.WriteLine($"\tEnum: {type.Name}");
                        FileData.AppendLine($"\tEnum: {type.Name}");
                        Console.WriteLine(
                            $"\t\tDescription: {((DocumentAttribute)attributeData.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description}\n"
                        );
                        FileData.AppendLine(
                           $"\t\tDescription: {((DocumentAttribute)attributeData.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description}\n"
                       );
                        

                        string[] names = type.GetEnumNames();
                        foreach (string name in names)
                        {
                            Console.WriteLine($"\t{name}\n");
                            FileData.AppendLine($"\t{name}\n");
                            DocumentAttribute.Add(
                                new DocumentAttribute
                                {
                                    Output = name,
                                    Description = (
                                        (
                                            (DocumentAttribute)
                                                attributeData.SingleOrDefault(
                                                    a => a.GetType() == typeof(DocumentAttribute)
                                                )
                                        )?.Description
                                    )
                                }
                            );
                        }
                    }
                }
            }
        }
    }
}
