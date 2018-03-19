using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;
using static SampleDB.UserGroupPageViewModel;

namespace SampleDB
{
    public partial class UserGroupPage : ContentPage
    {
        public int totalRecordCount;
        public int LastIndex;
        public int StartIndex;

        public UserGroupPage()
        {
            InitializeComponent();
            var userGroupPageViewModel = new UserGroupPageViewModel();
            this.BindingContext = userGroupPageViewModel;
            totalRecordCount =  userGroupPageViewModel.finalListObj.Count;

            previousBtn.IsEnabled = false;
            LastIndex = 8;
            StartIndex = 8;

            previousBtn.Clicked += (sender, e) => {
                int deviderVal = totalRecordCount % 8;
                var obj = userGroupPageViewModel.finalListObj.Count;
                if (StartIndex != 8){
                    LastIndex = LastIndex - 8;
                    userGroupPageViewModel.PrevButtonClicked(StartIndex, LastIndex);
                }
            };

            nextBtn.Clicked += (sender, e) => {
                if (LastIndex < totalRecordCount)
                {
                    LastIndex = LastIndex + 8;
                    previousBtn.IsEnabled = true;
                    var obj = userGroupPageViewModel.finalListObj.Count;
                    userGroupPageViewModel.NextButtonClicked(StartIndex,LastIndex);
                    StartIndex = StartIndex + 8;
                    if (StartIndex > totalRecordCount){
                        nextBtn.IsEnabled = false;
                    }
                }
            };

            //var assembly = typeof(DynamicScreen).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("SampleDB.UserGroup.json");
            //using (var reader = new System.IO.StreamReader(stream))
            //{

            //    var json = reader.ReadToEnd();
            //    UserGroupModel userGroupModel = JsonConvert.DeserializeObject<UserGroupModel>(json);

            //    List<Group> sortingGroup = new List<Group>();
            //    for (int i = 0; i < userGroupModel.Groups.Count; i++){
            //        if (userGroupModel.Groups[i].GroupType.Level_Id == 2){
            //            sortingGroup.Add(userGroupModel.Groups[i]);
            //        }
            //    }

            //    pickerRef.ItemsSource = sortingGroup;
            //}
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            JSSEInfo obj = mi.CommandParameter as JSSEInfo;
            DisplayAlert("", obj.jsseId.ToString(), "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            JSSEInfo obj = mi.CommandParameter as JSSEInfo;
            DisplayAlert("",obj.jsseId.ToString(), "OK");
        }
    }
}
