#ifndef PREFERENCESDIALOG_H
#define PREFERENCESDIALOG_H

#include <adwaita.h>
#include "../../models/configuration.h"

namespace NickvisionApplication::UI::Views
{
    typedef void (*Callback_GtkButton)(GtkButton*, gpointer*);

    class PreferencesDialog
    {
    public:
        PreferencesDialog(GtkWidget* parent);
        ~PreferencesDialog();
        GtkWidget* gobj();
        GtkBuilder* getBuilder();
        void show();

    private:
        GtkBuilder* m_builder = nullptr;
        NickvisionApplication::Models::Configuration m_configuration;
        //==Signals==//
        void save();
    };
}

#endif // PREFERENCESDIALOG_H