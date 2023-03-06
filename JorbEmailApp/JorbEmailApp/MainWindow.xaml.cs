using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace JorbEmailApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        const string HisHer = "hishertheir";
        const string HimHer = "himherthem";
        string Message { get; set; }
        struct FProunouns
        {
            public string HisHer { get; set; }
            public string HimHer { get; set; }
        }

        enum ETemplate
        {
            Template1,
            Template2
        }

        FProunouns ProunounsContainer = new FProunouns();
        ETemplate Template;

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Jorb Email App";

            IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32 { Width = 800, Height = 1100 });
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button)
            {
                return;
            }

            //para.Inlines.Clear();
            REBCustom.TextDocument.SetText(Microsoft.UI.Text.TextSetOptions.None, "");

            FindPronouns();

            switch (Template)
            {
                case ETemplate.Template1:
                    Message = $"Dear {ParentName.Text},\r\n\r\nIt was so great speaking with you. I really enjoyed learning about {MenteeName.Text} and {ProunounsContainer.HisHer} personality and interests, mentor preferences, what success would look like for {ProunounsContainer.HimHer}, and {ProunounsContainer.HisHer} goals for {EngagementTitle.Text}.\r\n\r\nConfirming {MenteeName.Text}’s student profile & learning needs\r\n\r\n\r\nHere is {MenteeName.Text}’s student profile. Do the notes in this profile look good to you? Would you like to make any edits? Once you’ve approved, we’ll send this to their mentor to ensure that they are prepared to provide {MenteeName.Text} with targeted support.\r\n\r\n\r\nThe goal\r\n{MenteeName.Text} hones in on something he is interested in and becomes a master of his craft, creating a passion project that differentiates him and helps his community.\r\nScheduling\r\nOnce weekly\r\nSessions\r\nWe’ll begin with 6 sessions of {MenteeName.Text}’s passion project mentorship. I will check in with you, {MenteeName.Text}, and his mentors after these 6 sessions to review progress and define success going forward.\r\nFeedback loops\r\nPlease visit {MenteeName.Text}’s student dashboard periodically to see their mentor's notes after every lesson. Learn more\r\n\r\nWe’ll check in with you after their first session to receive any additional feedback or input you might have.\r\n\r\n\r\n\r\n\r\n\r\n\r\nChoosing {MenteeName.Text}’s Mentor\r\n\r\nI wanted to reach out and share the mentors that I think would be a great fit for {MenteeName.Text}’s passion project mentorship. Each of these mentors share many nodes of connection with {MenteeName.Text}, having {SharedInterests.Text} in common, and they would each love to take {MenteeName.Text} on as a mentee. Please note that I have not yet checked these mentors' availabilities as I want to give {MenteeName.Text} the freedom of choice before reaching out:\r\n\r\n\r\n\r\n\r\n\r\nMichael Chhay\r\nMichael is a junior at Stanford University pursuing a major in Aeronautics and Astronautics and a minor in Computer Science. Academically, Michael is interested in math, physics, mechanical engineering, foreign languages, and creative writing. When he isn’t in class, Michael serves as Stanford Class President for the class of 2024. He is also a counselor for Stanford Kesem, a member of the Stanford Space Initiative on the satellites team, and a water polo player for the Stanford Club team. Michael has interned as a  research assistant for the Extreme Environment Microsystems Laboratory which focuses on developing super-materials in space! \r\nRead Michael’s complete biography →\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nIshaan Javali\r\nHey there! I'm Ishaan, a Princeton student studying Computer Science with a minor in Statistics & Machine Learning. I graduated as valedictorian of Plano East Senior High School where I served as an officer of Computer Science, Science Fair, and Math clubs for 3 years. \r\nWith a published research paper on landslide analytics, an app with 12k+ installs on the Google Play Store, 2 AI-related internships at Lockheed Martin, and several programming, math, and hackathon awards under my belt, I love technology and harnessing its power for real-world applications that people can benefit from…\r\nRead Ishaan’s complete biography →\r\n\r\n\r\n\r\n\r\n\r\n\r\nHere are your next steps:\r\nPlease let me know who {MenteeName.Text} would be most interested in working alongside. I will reach out to this mentor to confirm their availability, and from there we will start with a 6 session package. \r\nIf all looks good, I will send you an invoice for a 6-hour package ($510 total). We request packages to begin so that our mentors can plan concrete milestones, embed time with mentees into their schedule, and lay the groundwork for a real relationship. \r\nPlease see our parent handbook for information about billing, payment, and other policies (like our 24 hour cancellation policy).\r\n\r\n\r\nI am looking forward to introducing {MenteeName.Text} to his mentor!\r\n\r\n\r\n\r\n\r\nStay Curious,\r\nAlec Katz";
                    break;
                case ETemplate.Template2:
                    Message = $"Hi {ParentName.Text},\r\n\r\n\r\nI'm thrilled to introduce you to Mentor who is so excited to support {MenteeName.Text} in {GoalBox.Text}.\r\n\r\n\r\nHere is {MenteeName.Text}’s student profile overview. \r\n\r\n\r\n(We update these on a 6-12 month basis to keep up with students' progress and goals. We then share profiles with mentors to equip them to provide their mentees with targeted support. Please let me know if you would like to make any edits.)\r\n\r\n\r\nLet’s review their engagement!\r\n\r\n\r\nThe goal\r\n[INSERT WHAT SUCCESS LOOKS LIKE]\r\nScheduling\r\nOnce weekly\r\nSessions\r\n6 to start\r\nFeedback loops\r\nPlease visit {MenteeName.Text}'s student dashboard periodically to see their mentor's notes after every lesson. Learn more\r\n\r\nWe’ll check in with you after their first session to receive any additional feedback or input you might have.\r\n\r\n\r\n\r\nHere are your next steps:\r\n{Mentor.Text} will share scheduling options for your first session and share how to join the Zoom call from our platform. \r\nPlease find a time to begin with them next week, as schedules book up quickly.\r\nPlease determine a consistent, recurring time to meet so that {Mentor.Text} and {MenteeName.Text} can protect those times. Over the past two years, Curious Cardinals matches who have met at the same time each week have had our most effective, transformative  engagements. \r\nAs a reminder, please complete the steps below to set up your account to access lessons. This is necessary to access zoom links for lessons, which will be accessible on your dashboard, and on the calendar and email notifications you will receive when the mentor schedules the lesson:\r\nPlease go to https://app.curiouscardinals.com/sign-up. \r\nOnce signed in, you will be able to add a student to your account. Please share the password you created for them so that they can log in to our platform. Click here for a detailed guide!\r\nFinally, I wanted to introduce you to Lily, who leads student success. She will be your main point of contact going forward to address any questions or concerns and is here to ensure this is the most meaningful learning experience for {MenteeName.Text}.\r\nLet us know if you have questions or need support with anything from here.\r\nStay Curious,\r\n\r\n\r\n\r\n\r\nPACKAGE EMAIL\r\n\r\n\r\nParent name\r\nMentor name\r\nMentee name\r\nPronouns\r\nStripe package payment hyperlink\r\n\r\n\r\nHi {ParentName.Text}!\r\n\r\nI am so excited for {MenteeName.Text} to begin working with {Mentor.Text} and begin building a truly meaningful relationship together. \r\n\r\nPlease check your inbox for an introduction to {Mentor.Text}. [He/She/They] can't wait to work with {MenteeName.Text}! In that email thread, you’ll be able to schedule an intro session and share your availability for a recurring weekly schedule.\r\n\r\nPayment & next steps \r\n\r\nPlease pay for your first 6 sessions here, via online payment. Our most transformative matches are the engagements that meet consistently early-on. We ask for a package upfront so that our mentors can plan their sessions accordingly, set concrete milestones, and develop a strong relationship with their students! Please refer to our parent handbook for information about billing, payment, and other policies (like our 24 hour cancellation policy).\r\n\r\nMake sure {MenteeName.Text} can access their sessions\r\n\r\n⚠️ These next steps will enable you to access our secure Zoom links on the Platform, over email, and in calendar invites. {MenteeName.Text} won’t be able to log into their first session unless these are completed!\r\n\r\n\r\nSign into the Curious Cardinals Platform.\r\nOnce signed in, add a student to your account. \r\nPlease share the password you created for them so that they can log in when it’s time for sessions.\r\nSo excited for them to get started!\r\n\r\nStay Curious,";
                    break;
            }

            Run run = new Run();
            run.Text = Message;

            REBCustom.TextDocument.SetText(Microsoft.UI.Text.TextSetOptions.ApplyRtfDocumentDefaults, Message);
            //para.Inlines.Add(run);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button)
            {
                return;
            }

            //para.Inlines.Clear();
            REBCustom.TextDocument.SetText(Microsoft.UI.Text.TextSetOptions.None, "");
        }

        private void FindPronouns()
        {
            var PronounsList = Pronouns.Text.Split(',');
            foreach (var Pronouns in PronounsList)
            {
                string trimmed = Pronouns.Trim();
                if (HisHer.Contains(trimmed))
                {
                    ProunounsContainer.HisHer = trimmed;
                }

                if (HimHer.Contains(trimmed))
                {
                    ProunounsContainer.HimHer = trimmed;
                }
            }
        }

        private void Template1_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuFlyoutItem)
            {
                return;
            }

            //para.Inlines.Clear();
            REBCustom.TextDocument.SetText(Microsoft.UI.Text.TextSetOptions.None, "");

            GoalBox.Visibility = Visibility.Collapsed;
            GoalBlock.Visibility = Visibility.Collapsed;
            Mentor.Visibility = Visibility.Collapsed;
            MentorBlock.Visibility = Visibility.Collapsed;

            Template = ETemplate.Template1;
        }

        private void Template2_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not MenuFlyoutItem)
            {
                return;
            }

            //para.Inlines.Clear();
            REBCustom.TextDocument.SetText(Microsoft.UI.Text.TextSetOptions.None, "");

            GoalBox.Visibility = Visibility.Visible;
            GoalBlock.Visibility = Visibility.Visible;
            Mentor.Visibility = Visibility.Visible;
            MentorBlock.Visibility = Visibility.Visible;

            Template = ETemplate.Template2;
        }

        private void Menu_Opening(object sender, object e)
        {
            CommandBarFlyout myFlyout = sender as CommandBarFlyout;
            if (myFlyout.Target == REBCustom)
            {
                AppBarButton myButton = new AppBarButton();
                myButton.Command = new StandardUICommand(StandardUICommandKind.Share);
                myFlyout.PrimaryCommands.Add(myButton);
            }
        }

        private void REBCustom_Loaded(object sender, RoutedEventArgs e)
        {
            REBCustom.SelectionFlyout.Opening += Menu_Opening;
            REBCustom.ContextFlyout.Opening += Menu_Opening;
        }

        private void REBCustom_Unloaded(object sender, RoutedEventArgs e)
        {
            REBCustom.SelectionFlyout.Opening -= Menu_Opening;
            REBCustom.ContextFlyout.Opening -= Menu_Opening;
        }
    }
}
