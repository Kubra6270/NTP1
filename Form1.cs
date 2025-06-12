public partial class Form1 : Form
{
    private KargoYonetici kargoYonetici;
    private ListBox listBoxGonderiler;
    private Button btnGonderiEkle;
    private Button btnDurumGuncelle;
    private Button btnGonderiSorgula;

    public Form1()
    {
        InitializeComponent();
        kargoYonetici = new KargoYonetici();
        OrnekVerileriEkle();
        ListeyiGuncelle();
    }
    private void InitializeComponent()
    {
        this.listBoxGonderiler = new ListBox();
        this.btnGonderiEkle = new Button();
        this.btnDurumGuncelle = new Button();
        this.btnGonderiSorgula = new Button();
        this.SuspendLayout();
        this.Text = "Kargo Takip Sistemi";
        this.Size = new Size(800, 500);
        this.StartPosition = FormStartPosition.CenterScreen;

private void OrnekVerileriEkle()
{
    var yurticiKargo1 = new YurticiKargo("Ahmet Yılmaz", "Ankara", "Mehmet Demir", "İstanbul", 2.5, "İstanbul", "Kadıköy");
    var yurticiKargo2 = new YurticiKargo("Ayşe Kaya", "İzmir", "Fatma Öz", "Bursa", 1.8, "Bursa", "Osmangazi");
    var yurtdisiKargo1 = new YurtdisiKargo("Ali Veli", "İstanbul", "John Smith", "New York", 3.2, "ABD", "US001");
    var yurtdisiKargo2 = new YurtdisiKargo("Zeynep Ak", "Ankara", "Marie Dupont", "Paris", 1.5, "Fransa", "FR002");
    yurticiKargo1.DurumGuncelle(KargoDurum.Yolda); yurtdisiKargo1.DurumGuncelle(KargoDurum.TeslimEdildi);
    kargoYonetici.GonderiEkle(yurticiKargo1);
    kargoYonetici.GonderiEkle(yurticiKargo2);
    kargoYonetici.GonderiEkle(yurtdisiKargo1);
    kargoYonetici.GonderiEkle(yurtdisiKargo2);
}
    private void ListeyiGuncelle()
    {
        listBoxGonderiler.Items.Clear();
        foreach (var gonderi in kargoYonetici.TumGonderiler())
        {
            listBoxGonderiler.Items.Add(gonderi.TakipBilgisi());
        }
    }

    private void btnGonderiEkle_Click(object sender, EventArgs e)
    {
        using (var form = new GonderiEkleForm())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                kargoYonetici.GonderiEkle(form.YeniGonderi);
                ListeyiGuncelle();
                MessageBox.Show($"Gönderi başarıyla eklendi!\nTakip Numarası: {form.YeniGonderi.TakipNumarasi}",
                               "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void btnDurumGuncelle_Click(object sender, EventArgs e)
    {
        using (var form = new DurumGuncelleForm(kargoYonetici))
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                ListeyiGuncelle();
            }
        }
    }

    private void btnGonderiSorgula_Click(object sender, EventArgs e)
    }
        string takipNo = "";
        using (var inputForm = new InputBoxForm("Gönderi Sorgula", "Takip numarasını girin:"))
        {
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                takipNo = inputForm.UserInput;
            }
        }

        if (!string.IsNullOrEmpty(takipNo))
        {
            var gonderi = kargoYonetici.GonderiBul(takipNo);
            if (gonderi != null)
            {
                MessageBox.Show(gonderi.TakipBilgisi(), "Gönderi Detayları",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gönderi bulunamadı!", "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}private void CmbTip_SelectedIndexChanged(object sender, EventArgs e)
{
    if (cmbTip.SelectedIndex == 0) //yurtiçi
    {
        lblEkBilgi1.Text = "İl:";
        lblEkBilgi2.Text = "İlçe:";
    }
    else // yurtdışı
    {
        lblEkBilgi1.Text = "Ülke:";
        lblEkBilgi2.Text = "Gümrük Kodu:";
    }
    txtEkBilgi1.Visible = txtEkBilgi2.Visible = true;
    lblEkBilgi1.Visible = lblEkBilgi2.Visible = true;
}

private void BtnTamam_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrEmpty(txtGonderenAd.Text) || string.IsNullOrEmpty(txtAliciAd.Text) ||
            cmbTip.SelectedIndex == -1 || string.IsNullOrEmpty(txtAgirlik.Text))
        {
            MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
}

double agirlik = double.Parse(txtAgirlik.Text);

if (cmbTip.SelectedIndex == 0) // Yurtiçi
{
    YeniGonderi = new YurticiKargo(txtGonderenAd.Text, txtGonderenAdres.Text,
                                   txtAliciAd.Text, txtAliciAdres.Text, agirlik,
                                   txtEkBilgi1.Text, txtEkBilgi2.Text);
}
else // Yurtdışı
{
    YeniGonderi = new YurtdisiKargo(txtGonderenAd.Text, txtGonderenAdres.Text,
                                    txtAliciAd.Text, txtAliciAdres.Text, agirlik,
                                    txtEkBilgi1.Text, txtEkBilgi2.Text);
}
