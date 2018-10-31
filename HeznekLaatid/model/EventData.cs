using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeznekLaatid.entities;

namespace HeznekLaatid.model
{
    public class EventData
    {
        /* gets all the evnts from the list of events*/
        public static List<eventTbl> getAllEvents()
        {
            using (var db = new HeznekDB)
            {
                List<eventTbl> events = db.eventTbl.ToList();
                return events;
            }
        }
        /*update a specific event in the list of events*/
        public static void updateEventInList(eventTbl updatedEvent)
        {
            using (var db = new HeznekDB())
            {
                List<eventTbl> events = getAllEvents();

                foreach (var eventIndex in events)
                {
                    if (eventIndex.sn == updatedEvent.sn)
                    {
                        eventIndex.nameEvent = updatedEvent.nameEvent;
                        eventIndex.subjectEvent = updatedEvent.subjectEvent;
                        db.eventTbl.Remove(eventIndex);
                        db.eventTbl.Add(updatedEvent);
             //NOTE: here the updated event gets a new serial number(KEY)
                    }
                }
            }
        }
        /* add an vent to list of events*/
        public static void addEvent(eventTbl eventToAdd)
        {
            using (var db = new HeznekDB())
            {
                db.eventTbl.Add(eventToAdd);
                db.SaveChanges();
            }
        }
    }
}