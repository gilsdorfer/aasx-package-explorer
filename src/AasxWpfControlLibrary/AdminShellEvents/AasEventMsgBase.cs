﻿/*
Copyright (c) 2018-2019 Festo AG & Co. KG <https://www.festo.com/net/de_de/Forms/web/contact_international>
Author: Michael Hoffmeister

This source code is licensed under the Apache License 2.0 (see LICENSE.txt).

This source code may use other Open Source software components (see LICENSE.txt).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminShellNS;
using AasxPackageExplorer;

namespace AdminShellEvents
{
    /// <summary>
    /// Base class fro any AAS event. AAS events shall interoperably exchage asynchronous information between
    /// different execution environments "operating" AASes. This basic event class is described in AASiD Part 1.
    /// 
    /// Note: The Payload of the Event is realized by overloading this base class.
    /// </summary>
    public class AasEventMsgBase
    {
        /// <summary>
        /// Reference to the source EventElement, including identification of  AAS,  Submodel, SubmodelElements.
        /// </summary>
        public AdminShell.Reference Source { get; set; }

        /// <summary>
        /// SemanticId  of  the  source  EventElement,  if available.
        /// </summary>
        public AdminShell.SemanticId SourceSemanticId { get; set; }

        /// <summary>
        /// Reference  to  the  Referable,  which  defines  the scope  of  the  event.  Can  be  AAS,  Submodel, 
        /// SubmodelElementCollection  or SubmodelElement. 
        /// </summary>
        public AdminShell.Reference ObservableReference { get; set; }

        /// <summary>
        /// SemanticId  of  the  Referable,  which  defines  the scope of the event, if available. 
        /// </summary>
        public AdminShell.SemanticId ObservableSemanticId { get; set; }

        /// <summary>
        /// Information for the outer message infrastructure for  scheduling the  event to the  respective 
        /// communication channel.
        /// </summary>
        public string Topic { get; set; }

        /// <summary>
        /// ABAC-Subject, who/ which initiated the creation
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Timestamp  in  UTC,  when  this  event  was triggered.
        /// Note: this is the C# native implementation. May be, for serialization, another getter/ setter
        /// might be required.
        /// </summary>
        public DateTime Timestamp { get; set; }

        //
        // Constructor
        //

        public AasEventMsgBase() { }

        public AasEventMsgBase(
            DateTime timestamp,
            AdminShell.Reference source = null,
            AdminShell.SemanticId sourceSemanticId = null,
            AdminShell.Reference observableReference = null,
            AdminShell.SemanticId observableSemanticId = null,
            string topic = null, 
            string subject = null)
        {
            Timestamp = timestamp;
            Source = source;
            SourceSemanticId = sourceSemanticId;
            ObservableReference = observableReference;
            ObservableSemanticId = observableSemanticId;
            Topic = topic;
            Subject = subject;
        }

        //
        // Serialisation
        //

        public override string ToString()
        {
            var res = $"{this.GetType()}: " +
                $"{"" + Timestamp.ToString()} @ "+
                $"Source={"" + Source?.ToString()}, " +
                $"SourceSemanticId={"" + SourceSemanticId?.ToString()}, " +
                $"ObservableReference={"" + ObservableReference?.ToString()}, " +
                $"ObservableSemanticId={"" + ObservableSemanticId?.ToString()}, " +
                $"Topic=\"{"" + Topic}\", " +
                $"Subject=\"{"" + Subject}\", ";
            return res;
        }
        
    }
}