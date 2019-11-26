using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> allActivities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();


        public MainWindow()
        {
            InitializeComponent();
        }
        //Set an action for when the page is loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //create some activity objects
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic.",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane.",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region.",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };
            //adding the activities to the list created above
            allActivities.Add(l1);
            allActivities.Add(l2);
            allActivities.Add(l3);
            allActivities.Add(w1);
            allActivities.Add(w2);
            allActivities.Add(w3);
            allActivities.Add(a1);
            allActivities.Add(a2);
            allActivities.Add(a3);
            allActivities.Sort();
            allActivities.Reverse();

            //Displaying them in the listbox
            lbxProducts.ItemsSource = allActivities;
        }
        /*Implement add functionality to move an activity to selected activities.
        This should remove an activity from all activities and display it in the 
        selected activities listbox.If nothing is selected clicking on the add button should 
        display a message that nothing has been selected.If there is a date conflict an 
        appropriate message should be displayed.*/

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Display these activities in the Listbox to the left of the screen 
            //Figuring out which activity was selected.
            Activity selectedActivity = lbxProducts.SelectedItem as Activity;

            //Null check
            if (selectedActivity != null)
            {
                //Moves item from left box to right box
                allActivities.Remove(selectedActivity);
                selectedActivities.Add(selectedActivity);
                //refreshing the box
                RefreshPage();
            }
            else
            {
                MessageBox.Show("Nothing Selected");
            }
        }
        //7.	Implement remove functionality to remove an activity from selected activities.
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //Figuring out which activity was selected.
            Activity selectedActivity = lbxCart.SelectedItem as Activity;

            //Null check
            if (selectedActivity != null)
            {
                //Moves item from left box to right box
                allActivities.Add(selectedActivity);
                selectedActivities.Remove(selectedActivity);
                //Refreshing the page
                RefreshPage();
            }
        }
        //Display the description when an activity is selected from the listbox. 
        private void LbxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Figuring out which activity was selected.
            Activity selectedActivity = lbxProducts.SelectedItem as Activity;

            //Null check
            if (selectedActivity != null)
            {

                //Adds the required description the the textbox underneath.
                txtblkDescription.Text = selectedActivity.Description;
                //Displays the cost of the item
                string cost = selectedActivity.Cost.ToString();
                txtbxCost.Text = cost;
            
            }
        }

        private void RefreshPage()
        {
            //refreshing the box
            lbxProducts.ItemsSource = null;
            lbxProducts.ItemsSource = allActivities;
            //Adding to the right listbox
            lbxCart.ItemsSource = null;
            lbxCart.ItemsSource = selectedActivities;
        }
        /*Implement filter functionality to filter activities in the All Activities listbox.
        If nothing has been selected to remove an appropriate message should be displayed.*/
        private void RadioButton_All(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();
            if (rb_All.IsChecked == true)
            {

                RefreshPage();
            }
            else if (rb_Land.IsChecked == true)
            {
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredActivities.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivities;

                    }
                }
            }
            else if (rb_Water.IsChecked == true)
            {
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (rb_Air.IsChecked == true)
            {
                foreach (Activity activity in allActivities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxProducts.ItemsSource = null;
                        lbxProducts.ItemsSource = filteredActivities;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nothing has been selected");
            }


        }

    }
}
