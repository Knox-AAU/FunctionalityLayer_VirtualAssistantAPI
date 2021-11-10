﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAssistantBusinessLogic.KnowledgeGraph;

namespace VirtualAssistantBusinessLogic.SparQL
{
    public class SparQLBuilder
    {
        public SparQLBuilder()
        {
            SPOEncoder = new SPOEncoder();
        }

        public string Query { get; set; }
        protected SPOEncoder SPOEncoder { get; set; }

        public override string ToString()
        {
             //TODO split into subject and predicate and lemmatize
            string subject = Query;

            EncodedSPO encodedSubject = SPOEncoder.EncodeSubject(subject);

            SparQLSelect sparQLSelect = new SparQLSelect();
            //Return the SparQL string
            return sparQLSelect.From(encodedSubject)//TODO change from to the initial queries resulting start node
                        .Select("Predicate", "Object")
                        .Where()
                            .SubjectIs(encodedSubject).PredicateAs("Predicate").ObjectAs("Object")
                        .ToString();
        }
    }
}