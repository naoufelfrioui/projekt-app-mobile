using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Models
{
    class Dictionar
    {
       public Dictionary<string, string> Arabic { get; set; }
       public Dictionary<string, string> English { get; set; }
       
        public Dictionar()
        {
            Arabic = new Dictionary<string, string>();
            English = new Dictionary<string, string>();
            ArabicDictionary();
            DeutschDictionary();
        }

        public void ArabicDictionary()
        {
            Arabic.Add("menu1", "قائمة عادلة");
            Arabic.Add("menu2", "أحداث عادلة");
            Arabic.Add("menu3", "بحث");
            Arabic.Add("menu4", "تحميل القائمة");
            Arabic.Add("menu5", "اتصال");
            Arabic.Add("SecondaryButton1", "ملف تعريفي للمستخدم");
            Arabic.Add("SecondaryButton2", "ضبط");

            //Settings Page 
            Arabic.Add("SettingspageHeader", "صفحة الإعدادات");
            Arabic.Add("About", "حول");
            Arabic.Add("Privacystatement", "بيان الخصوصية");
            Arabic.Add("SettingsHeader", "ضبط");
            Arabic.Add("UseShellDrawnBackButtonToggleSwtichHeader", "زر تعادل شل تعادل");
            Arabic.Add("UseShellDrawnBackButtonToggleSwtichOffContent", "زر الرجوع في رأس الصفحة");
            Arabic.Add("UseShellDrawnBackButtonToggleSwtichOnContent", "زر العودة في العنوان / شريط المهام");

            Arabic.Add("UseLightThemeToggleSwitchHeader", "طلب تطبيق الموضوع");
            Arabic.Add("UseLightThemeToggleSwitchOffContent", "الموضوع الحالي هو الظلام");
            Arabic.Add("UseLightThemeToggleSwitchOnContent", "الموضوع الحالي هو الضوء");

            Arabic.Add("ShowHamburgerButtonToggleSwitchHeader", "زر الرؤية");
            Arabic.Add("ShowHamburgerButtonToggleSwitchOffContent", "يتم إخفاء زر");
            Arabic.Add("ShowHamburgerButtonToggleSwitchOnContent", "الزر مرئي");

            Arabic.Add("IsFullScreenToggleSwitchHeader", "محتوى الصفحة هو ملء الشاشة");
            Arabic.Add("IsFullScreenToggleSwitchOffContent", "القائمة  مرئية");
            Arabic.Add("IsFullScreenToggleSwitchOnContent", "القائمة مخفية");

            Arabic.Add("languages", "اللغات");
            Arabic.Add("English", "الإنجليزية");
            Arabic.Add("Arabic", "العربية");
            Arabic.Add("BusyTextTextBox", "نص مشغول");
            Arabic.Add("ShowBusyButton", "عرض مشغول");


        }

        public void DeutschDictionary()
        {
            English.Add("menu1", "Messe Liste");
            English.Add("menu2", "Messe Events ");
            English.Add("menu3", "Search ");
            English.Add("menu4", "Download ");
            English.Add("menu5", "Contact");
            English.Add("SecondaryButton1", "User profile");
            English.Add("SecondaryButton2", "Settings");

            //Settings Page 
            English.Add("SettingspageHeader", "Settings Page");
            English.Add("About", "About");
            English.Add("Privacystatement", "Privacy statement");
            English.Add("SettingsHeader", "Settings ");
            English.Add("UseShellDrawnBackButtonToggleSwtichHeader", "Shell-drawn Back Button");
            English.Add("UseShellDrawnBackButtonToggleSwtichOffContent", "Back button is in Page Header");
            English.Add("UseShellDrawnBackButtonToggleSwtichOnContent", "Back button in Title/TaskBar");

            English.Add("UseLightThemeToggleSwitchHeader", "Requested Application Theme");
            English.Add("UseLightThemeToggleSwitchOffContent", "Current theme is Dark");
            English.Add("UseLightThemeToggleSwitchOnContent", "Current theme is Light");

            English.Add("ShowHamburgerButtonToggleSwitchHeader", "Hamburger Button Visibility");
            English.Add("ShowHamburgerButtonToggleSwitchOffContent", "Hamburger Button is hidden");
            English.Add("ShowHamburgerButtonToggleSwitchOnContent", "Hamburger Button is visible");

            English.Add("IsFullScreenToggleSwitchHeader", "Page content is Full Screen");
            English.Add("IsFullScreenToggleSwitchOffContent", "Hamburger Menu is visible");
            English.Add("IsFullScreenToggleSwitchOnContent", "Hamburger Menu is hidden");

            English.Add("languages", "languages");
            English.Add("English", "English");
            English.Add("Arabic", "Arabic");
            English.Add("BusyTextTextBox", "Busy text");
            English.Add("ShowBusyButton", "Show Busy");
        }
    }
    
}
