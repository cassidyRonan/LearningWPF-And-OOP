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

namespace LabNine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Members
        Member JD = new Member();
        Member MB = new Member("Mary Bloggs","0872345098","Middle Of Nowhere, Galway",Member.MemberType.OAP,Utility.RandomNext(2000,2015));
        Member JB = new Member("Jim Bloggs", "0875667123", "Middle Of Somehwere, Galway", Member.MemberType.OffPeak, Utility.RandomNext(2000, 2015));
        Member SB = new Member("Sue Blas", "0832349998", "Short Walk, Sligo", Member.MemberType.Student, Utility.RandomNext(2000, 2015));

        List<Member> members = new List<Member>();    

        //Events and Methods
        public MainWindow()
        {
            InitializeComponent();

            //Members Added
            members.Add(JD);
            members.Add(MB);
            members.Add(JB);
            members.Add(SB);
            //lstbxMembers.DataContext = members;
            lstbxMembers.ItemsSource = members;


            //set source of combo box
            cmbbxFilterMembers.ItemsSource = GetMemberhipTypes();
        }

        private void LstbxMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Member info = (Member)lstbxMembers.SelectedItem;
            txtbkMemberInfo.Text = info.DisplayMemberDetails();

           
        }

        private List<String> GetMemberhipTypes()
        {
            List<String> list = new List<string>();
            //addng all as an option to view all members
            list.Add("All");

            string[] names = Enum.GetNames(typeof(Member.MemberType));

            list.AddRange(names);

            //foreach (var m in members)
            //{
            //    list.Add(m.MemberShipType.ToString());
            //}
            return list;
        }

        private void CmbbxFilterMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
