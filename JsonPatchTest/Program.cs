﻿using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using Newtonsoft.Json;

namespace JsonPatchTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = new Foo { Name = "name", Text = "text" };
            var b = new Foo { Name = "nameb", Text = "text" };

            var jp = CreatePatch(a, b);
            jp.ApplyTo(a);
            Console.WriteLine(JsonConvert.SerializeObject(jp));
            Console.WriteLine(JsonConvert.SerializeObject(a));

            Console.WriteLine("Hello World!");
        }

        public static JsonPatchDocument CreatePatch(object originalObject, object modifiedObject)
        {
            var original = JObject.FromObject(originalObject);
            var modified = JObject.FromObject(modifiedObject);

            var patch = new JsonPatchDocument();
            FillPatchForObject(original, modified, patch, "/");

            return patch;
        }

        private static void FillPatchForObject(JObject orig, JObject mod, JsonPatchDocument patch, string path)
        {
            var origNames = orig.Properties().Select(x => x.Name).ToArray();
            var modNames = mod.Properties().Select(x => x.Name).ToArray();

            // Names removed in modified
            foreach (var k in origNames.Except(modNames))
            {
                var prop = orig.Property(k);
                patch.Remove(path + prop.Name);
            }

            // Names added in modified
            foreach (var k in modNames.Except(origNames))
            {
                var prop = mod.Property(k);
                patch.Add(path + prop.Name, prop.Value);
            }

            // Present in both
            foreach (var k in origNames.Intersect(modNames))
            {
                var origProp = orig.Property(k);
                var modProp = mod.Property(k);

                if (origProp.Value.Type != modProp.Value.Type)
                {
                    patch.Replace(path + modProp.Name, modProp.Value);
                }
                else if (!string.Equals(
                                origProp.Value.ToString(Newtonsoft.Json.Formatting.None),
                                modProp.Value.ToString(Newtonsoft.Json.Formatting.None)))
                {
                    if (origProp.Value.Type == JTokenType.Object)
                    {
                        // Recurse into objects
                        FillPatchForObject(origProp.Value as JObject, modProp.Value as JObject, patch, path + modProp.Name + "/");
                    }
                    else
                    {
                        // Replace values directly
                        patch.Replace(path + modProp.Name, modProp.Value);
                    }
                }
            }
        }
    }

    internal class Foo
    {
        public string Name { get; set; }

        public string Text { get; set; }
    }
}