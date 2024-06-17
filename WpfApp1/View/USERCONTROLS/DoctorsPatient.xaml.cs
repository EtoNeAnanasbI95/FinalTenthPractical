using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FinalTenthPractical.View.USERCONTROLS;

public partial class DoctorsPatient : UserControl
{
    private Dictionary<int, string> imagePaths = new Dictionary<int, string>
    {
        {1, @"..\..\..\Model\img\doctor.png"},
        {2, @"..\..\..\Model\img\ophthalmologist.png"},
        {3, @"..\..\..\Model\img\traumatologist.png"},
        {4, @"..\..\..\Model\img\surgeon.png"},
        {5, @"..\..\..\Model\img\gynecologist.png"},
        {6, @"..\..\..\Model\img\dentist.png"},
        {7, @"..\..\..\Model\img\cardiologist.png"},
        {8, @"..\..\..\Model\img\oncologist.png"},
        {9, @"..\..\..\Model\img\psychologist.png"},
        {10, @"..\..\..\Model\img\otorhinolaryngologist.png"},
    };
    
    private Dictionary<int, string> imageName = new Dictionary<int, string>
    {
        {1, "Педиатор"},
        {2, "Офтальмолог"},
        {3, "Травматолог"},
        {4, "Хирург"},
        {5, "Гинеколог"},
        {6, "Стоматолог"},
        {7, "Кардиолог"},
        {8, "Онколог"},
        {9, "Психолог"},
        {10, "ЛОР"}
    };

    private int _idSpecials;

    public string path { get; set; }
    
    public int IdSpecials
    {
        get => _idSpecials;
        
        set
        {
            _idSpecials = value;
            TextBlock.Text = imageName[value];
            Console.WriteLine(imageName[value]);
            
            Console.WriteLine(imagePaths[value]);
            string imagePath = imagePaths[value];
            Uri imageUri = new Uri(imagePath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);

            Image.Source = imageBitmap;
        }
    }
    
    public DoctorsPatient()
    {
        InitializeComponent();
        Onclick.Click += (sender, args) => OnCardClick(sender, args);
    }

    public event EventHandler Click;
    

    private void OnCardClick(object sender, EventArgs e)
    {
        Click?.Invoke(sender, e);
    }
}