﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code_Secret_SOEMS.Models;

namespace Code_Secret_SOEMS.Presenters
{
    class EventRegistrationPresenter
    {

        public int student_slots { get; set; }
        public int guest_slots { get; set; }

        Guest _guest = new Guest();
        Event _event = new Event();
        public string getSchoolName()
        {
            return Properties.Settings.Default.schoolName;
        }

        public void setEvents(ComboBox cmbEvents)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _event.getAllActiveEvents();
            cmbEvents.DataSource = bindingSource;
            cmbEvents.SelectedIndex = -1;
        }

        public int eventID(string event_name)
        {
            _event.selectEventByName(event_name);
            return int.Parse(_event.getEventItems("id"));
        }

        public int getStudentSlots()
        {
            return student_slots;
        }

        public int getGuestSlots()
        {
            return guest_slots;
        }

        public void prepareEvent(ComboBox cmbEvents, Panel panelEvents, Label lblEventName, Label lblVenue, Label lblDate,
            Label lblTime, TextBox txtEventDetails, Panel panelStudentRegistration, Label lblStudentSlots, Label lblStudentRegistrationFee,
            Panel panelGuestRegistration, Label lblGuestSlots, Label lblGuestRegistrationFee)
        {
            _event.selectEvent(this.eventID(cmbEvents.Text));
            lblEventName.Text = cmbEvents.Text;
            lblEventName.Left = (panelEvents.Width - lblEventName.Width) / 2;
            lblVenue.Text = "Venue: " + _event.getEventItems("venue");
            lblDate.Text = "Date: " + _event.getEventItems("date");
            lblTime.Text = "Time: " + _event.getEventItems("time");
            txtEventDetails.Text = _event.getEventItems("event_details");
            student_slots = int.Parse(_event.getEventItems("student_slots"));
            panelStudentRegistration.Enabled = true;
            if (student_slots == 0)
            {
                lblStudentSlots.Text = "Slots Left: Open";
            }
            else
            {
                lblStudentSlots.Text = "Slots Left: " + student_slots.ToString();
            }
            lblStudentRegistrationFee.Text = "Registation Fee: Php " + _event.getEventItems("student_registration");
            if (bool.Parse(_event.getEventItems("allow_guests")))
            {
                panelGuestRegistration.Enabled = true;
                guest_slots = int.Parse(_event.getEventItems("guest_slots"));
                if (guest_slots == 0)
                {
                    lblGuestSlots.Text = "Slots Left: Open";
                }
                else
                {
                    lblGuestSlots.Text = "Guest Slots: " + guest_slots.ToString();
                }
                lblGuestRegistrationFee.Text = "Registration Fee: Php " + _event.getEventItems("guest_registration");
            } else
            {
                panelGuestRegistration.Enabled = false;
                lblGuestSlots.Text = "Slots Left: ";
                lblGuestRegistrationFee.Text = "Registration Fee: ";
            }
        }
    }
}
