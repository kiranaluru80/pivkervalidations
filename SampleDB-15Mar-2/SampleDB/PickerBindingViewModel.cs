using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace SampleDB
{
    public class PickerBindingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<PickerResponceModel> MajorGroupNames { get; set; }


        string organizationGroupTitle = "Select Organizations Name";
        public string OrganizationGroupTitle
        {
            get { return organizationGroupTitle; }
            set
            {
                if (organizationGroupTitle != value)
                {
                    organizationGroupTitle = value;
                    OnPropertyChanged("OrganizationGroupTitle");
                }
            }
        }

        string departmentGroupTitle = "Select DepartmentName";
        public string DepartmentGroupTitle
        {
            get { return departmentGroupTitle; }
            set
            {
               // if (departmentGroupTitle != value)
               // {
                Device.BeginInvokeOnMainThread(() => {
                    departmentGroupTitle = value;
                    OnPropertyChanged("DepartmentGroupTitle");
                });
                    
                    
               // }
            }
        }


        bool organizationsPickerVisible = false;
        public bool OrganizationsPickerVisible
        {
            get { return organizationsPickerVisible; }
            set
            {
                if (organizationsPickerVisible != value)
                {
                    organizationsPickerVisible = value;
                    OnPropertyChanged("OrganizationsPickerVisible");
                }
            }
        }


        bool departmentPickerVisible = false;
        public bool DepartmentPickerVisible
        {
            get { return departmentPickerVisible; }
            set
            {
                if (departmentPickerVisible != value)
                {
                    DepartmentGroupTitle = "Select DepartmentName";
                    departmentPickerVisible = value;
                    OnPropertyChanged("DepartmentPickerVisible");
                }
            }
        }




        List<Department> departmentNames;
        public List<Department> DepartmentNames
        {
            get { return departmentNames; }
            set
            {
                if (departmentNames != value)
                {
                    departmentNames = value;
                    DepartmentGroupTitle = "Select DepartmentName";
                    OnPropertyChanged("DepartmentNames");
                }
            }
        }


        Department selectedDepartMentGroupName;
        public Department SelectedDepartMentGroupName
        {
            get { return selectedDepartMentGroupName; }
            set
            {
                if (selectedDepartMentGroupName != value)
                {
                    selectedDepartMentGroupName = value;
                    DepartmentGroupTitle = "Select DepartmentName";
                    OnPropertyChanged("SelectedDepartMentGroupName");
                }
            }
        }


        List<Organization> organizationsNames;
        public List<Organization> OrganizationsNames
        {
            get { return organizationsNames; }
            set
            {
                if (organizationsNames != value)
                {
                    organizationsNames = value;
                    DepartmentGroupTitle = "Select DepartmentName";
                    OnPropertyChanged("OrganizationsNames");
                }
            }
        }


        Organization selectedOrganizationsGroupName;
        public Organization SelectedOrganizationsGroupName
        {
            get { return selectedOrganizationsGroupName; }
            set
            {
                if (selectedOrganizationsGroupName != value && value != null)
                {
                    DepartmentGroupTitle = "Select DepartmentName";

                    selectedOrganizationsGroupName = value;
                    DepartmentNames = value.Departments;
                    DepartmentPickerVisible = true;
                    OnPropertyChanged("SelectedOrganizationsGroupName");
                }
            }
        }




        PickerResponceModel selectedMajorGroupName;
        public PickerResponceModel SelectedMajorGroupName
        {
            get { return selectedMajorGroupName; }
            set
            {
                if (selectedMajorGroupName != value)
                {
                    
                    selectedMajorGroupName = value;
                    OrganizationsNames = value.Organizations;
                    OrganizationsPickerVisible = true;
                    OrganizationGroupTitle = "Select Organizations Name";

                    OnPropertyChanged("SelectedMajorGroupName");

                    DepartmentGroupTitle = "Select DepartmentName";
                    DepartmentPickerVisible = false;
                }
            }

        }


        public PickerBindingViewModel()
        {

            var assembly = typeof(DynamicScreen).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("SampleDB.PickerJsonFile.json");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<PickerResponceModel> userGroupModel = JsonConvert.DeserializeObject<List<PickerResponceModel>>(json);
                MajorGroupNames = userGroupModel;
            }

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
