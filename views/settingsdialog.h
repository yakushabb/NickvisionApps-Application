#ifndef SETTINGSDIALOG_H
#define SETTINGSDIALOG_H

#include <gtkmm.h>
#include "../models/configuration.h"

namespace NickvisionApplication::Views
{
    class SettingsDialog : public Gtk::Dialog
    {
    public:
        SettingsDialog(Gtk::Window& parent);
        ~SettingsDialog();

    private:
        NickvisionApplication::Models::Configuration m_configuration;
        Gtk::CheckButton m_chkIsFirstTimeOpen;
    };
}

#endif // SETTINGSDIALOG_H