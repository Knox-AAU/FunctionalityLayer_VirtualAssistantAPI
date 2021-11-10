﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualAssistantBusinessLogic.KnowledgeGraph;

namespace VirtualAssistantBusinessLogic.SparQL
{
    public class PersonSparQLBuilder : SparQLBuilder
    {
        public override string ToString()
        {
            //TODO split into subject and predicate and lemmatize
            string subject = Query;

            EncodedSPO encodedSubject = new EncodedSPO("", subject);

            SparQLSelect sparQLSelect = new SparQLSelect();
            //Return the SparQL string
            return sparQLSelect.From(encodedSubject)
                        .Select("Occupation", "birth_name", "date_of_birth", "Spouse")
                        .Where()
                            .SubjectIs(encodedSubject).PredicateIs(SPOEncoder.EncodePredicate("Type")).ObjectAs("Type")
                            .SubjectIs(encodedSubject).PredicateIs(SPOEncoder.EncodePredicate("Occupation")).ObjectAs("Occupation")
                            .SubjectIs(encodedSubject).PredicateIs(SPOEncoder.EncodePredicate("birth name")).ObjectAs("birth_name")
                            .SubjectIs(encodedSubject).PredicateIs(SPOEncoder.EncodePredicate("date of birth")).ObjectAs("date_of_birth")
                            .SubjectIs(encodedSubject).PredicateIs(SPOEncoder.EncodePredicate("Spouse")).ObjectAs("Spouse")
                        .ToString();
        }
    }
}
