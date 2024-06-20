using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FinalTenthPractical.View.USERCONTROLS;

public partial class DoctorsPatient : UserControl
{
    private readonly Dictionary<int, string> imageName = new()
    {
        { 1, "Педиатор" },
        { 2, "Офтальмолог" },
        { 3, "Травматолог" },
        { 4, "Хирург" },
        { 5, "Гинеколог" },
        { 6, "Стоматолог" },
        { 7, "Кардиолог" },
        { 8, "Онколог" },
        { 9, "Психолог" },
        { 10, "ЛОР" },
        { 11, "Дежурный врач" },
        { 12, "Вакцинация от COVID-19" }
    };

    private readonly Dictionary<int, string> imagePaths = new()
    {
        { 1, @"..\..\..\Model\img\doctor.png" },
        { 2, @"..\..\..\Model\img\ophthalmologist.png" },
        { 3, @"..\..\..\Model\img\traumatologist.png" },
        { 4, @"..\..\..\Model\img\surgeon.png" },
        { 5, @"..\..\..\Model\img\gynecologist.png" },
        { 6, @"..\..\..\Model\img\dentist.png" },
        { 7, @"..\..\..\Model\img\cardiologist.png" },
        { 8, @"..\..\..\Model\img\oncologist.png" },
        { 9, @"..\..\..\Model\img\psychologist.png" },
        { 10, @"..\..\..\Model\img\otorhinolaryngologist.png" },
        { 11, @"..\..\..\Model\img\emergency.png" },
        { 12, @"..\..\..\Model\img\covid.png" }
    };

    private int _idSpecials;

    public DoctorsPatient()
    {
        InitializeComponent();
        Onclick.Click += (sender, args) => OnCardClick(sender, args);
    }

    public string path { get; set; }

    public int IdSpecials
    {
        get => _idSpecials;

        set
        {
            _idSpecials = value;
            TextBlock.Text = imageName[value];
            var imagePath = imagePaths[value];
            var imageUri = new Uri(imagePath, UriKind.Relative);
            var imageBitmap = new BitmapImage(imageUri);

            Image.Source = imageBitmap;
        }
    }

    public event EventHandler Click;

    private void OnCardClick(object sender, EventArgs e)
    {
        Click?.Invoke(this, e);
    }
}