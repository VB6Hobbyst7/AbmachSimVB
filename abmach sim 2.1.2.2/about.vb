Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports SHDocVw
Namespace abmach
    _

    '/ <summary>
    '/    Summary description for about.
    '/ </summary>
    Public Class about
        Inherits System.Windows.Forms.Form
        '/ <summary>
        '/    Required designer variable.
        '/ </summary>
        Private components As System.ComponentModel.Container
        Private WithEvents button1 As System.Windows.Forms.Button
        Private label1 As System.Windows.Forms.Label


        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        End Sub 'New

  

        '/ <summary>
        '/    Clean up any resources being used.
        '/ </summary>
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose


        '/ <summary>
        '/    Required method for Designer support - do not modify
        '/    the contents of this method with the code editor.
        '/ </summary>
        Friend WithEvents contactinfo As System.Windows.Forms.LinkLabel
        Friend WithEvents companylink As System.Windows.Forms.LinkLabel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Version As System.Windows.Forms.Label
        Friend WithEvents companyLabel As System.Windows.Forms.Label
        Friend WithEvents description As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents product As System.Windows.Forms.Label
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label
            Me.button1 = New System.Windows.Forms.Button
            Me.contactinfo = New System.Windows.Forms.LinkLabel
            Me.companylink = New System.Windows.Forms.LinkLabel
            Me.Version = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.companyLabel = New System.Windows.Forms.Label
            Me.description = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.product = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
            Me.label1.Location = New System.Drawing.Point(32, 40)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(88, 21)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Created By"
            Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'button1
            '
            Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.button1.Location = New System.Drawing.Point(144, 208)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(56, 24)
            Me.button1.TabIndex = 3
            Me.button1.Text = "&OK"
            '
            'contactinfo
            '
            Me.contactinfo.Location = New System.Drawing.Point(112, 168)
            Me.contactinfo.Name = "contactinfo"
            Me.contactinfo.Size = New System.Drawing.Size(120, 16)
            Me.contactinfo.TabIndex = 4
            Me.contactinfo.TabStop = True
            Me.contactinfo.Text = "nickc@ormondllc.com"
            '
            'companylink
            '
            Me.companylink.Location = New System.Drawing.Point(120, 184)
            Me.companylink.Name = "companylink"
            Me.companylink.Size = New System.Drawing.Size(112, 16)
            Me.companylink.TabIndex = 5
            Me.companylink.TabStop = True
            Me.companylink.Text = "www.ormondllc.com"
            '
            'Version
            '
            Me.Version.AutoSize = True
            Me.Version.Location = New System.Drawing.Point(80, 96)
            Me.Version.Name = "Version"
            Me.Version.Size = New System.Drawing.Size(14, 16)
            Me.Version.TabIndex = 6
            Me.Version.Text = "1."
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(32, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(46, 16)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "Version:"
            '
            'companyLabel
            '
            Me.companyLabel.AutoSize = True
            Me.companyLabel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.companyLabel.Location = New System.Drawing.Point(144, 40)
            Me.companyLabel.Name = "companyLabel"
            Me.companyLabel.Size = New System.Drawing.Size(78, 22)
            Me.companyLabel.TabIndex = 9
            Me.companyLabel.Text = "Company"
            Me.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'description
            '
            Me.description.AutoSize = True
            Me.description.Location = New System.Drawing.Point(96, 120)
            Me.description.Name = "description"
            Me.description.Size = New System.Drawing.Size(61, 16)
            Me.description.TabIndex = 10
            Me.description.Text = "Description"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(32, 120)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 10
            Me.Label2.Text = "Description:"
            '
            'product
            '
            Me.product.AutoSize = True
            Me.product.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
            Me.product.Location = New System.Drawing.Point(32, 16)
            Me.product.Name = "product"
            Me.product.Size = New System.Drawing.Size(65, 21)
            Me.product.TabIndex = 0
            Me.product.Text = "Product"
            '
            'about
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(342, 258)
            Me.Controls.Add(Me.description)
            Me.Controls.Add(Me.companyLabel)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Version)
            Me.Controls.Add(Me.companylink)
            Me.Controls.Add(Me.contactinfo)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.product)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "about"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "About ABMACHSim"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub 'InitializeComponent


        Protected Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            Me.Close()
        End Sub 'button1_Click



        Private Sub contactinfo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles contactinfo.LinkClicked
            System.Diagnostics.Process.Start("mailTo:nickc@ormondllc.com")
        End Sub

        Private Sub companylink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles companylink.LinkClicked
            Dim o As Object = Nothing

            Dim ie As New SHDocVw.InternetExplorerClass

            Dim wb As IWebBrowserApp = CType(ie, IWebBrowserApp)
            wb.Visible = True

            'Do anything else with the window here that you wish
            wb.Navigate(Me.companylink.Text, o, o, o, o)

        End Sub

        Private Sub about_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim assinfo As New clsAppInfo
            Me.Version.Text = assinfo.Version()
            Me.companyLabel.Text = assinfo.Company()
            Me.description.Text = assinfo.Description()
            Me.product.Text = assinfo.Product()

        End Sub
    End Class 'about
End Namespace 'abmach