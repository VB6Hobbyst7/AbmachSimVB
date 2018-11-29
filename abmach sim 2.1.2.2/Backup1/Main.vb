'By Nick Cooksey
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO 'For file handling
Imports System.Drawing.Printing 'For Printing
Imports Microsoft.Win32
Imports System.Threading
Imports System.Xml

Namespace abmach



    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private components As System.ComponentModel.IContainer
        Private WithEvents mnuAbout As System.Windows.Forms.MenuItem
        Private menuItem7 As System.Windows.Forms.MenuItem
        Private menuItem6 As System.Windows.Forms.MenuItem
        Private colorDialog1 As System.Windows.Forms.ColorDialog
        Private fontDialog1 As System.Windows.Forms.FontDialog
        'private System.Windows.Forms.MenuItem mnuFontColor;
        Private WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
        Private menuItem5 As System.Windows.Forms.MenuItem
        Private WithEvents mnuDelete As System.Windows.Forms.MenuItem
        Private WithEvents mnuCut As System.Windows.Forms.MenuItem
        Private menuItem2 As System.Windows.Forms.MenuItem
        Private WithEvents mnuUndo As System.Windows.Forms.MenuItem
        Private pageSetupDialog1 As System.Windows.Forms.PageSetupDialog
        Private printDialog1 As System.Windows.Forms.PrintDialog
        Private WithEvents mnuExit As System.Windows.Forms.MenuItem
        Private menuItem12 As System.Windows.Forms.MenuItem
        Private WithEvents mnuPrint As System.Windows.Forms.MenuItem
        Private WithEvents mnuPageSetUp As System.Windows.Forms.MenuItem
        Private menuItem9 As System.Windows.Forms.MenuItem
        Private WithEvents mnuPaste As System.Windows.Forms.MenuItem
        Private WithEvents mnuCopy As System.Windows.Forms.MenuItem
        Private mnuEdit As System.Windows.Forms.MenuItem
        Private WithEvents mnuSaveAs As System.Windows.Forms.MenuItem
        Private WithEvents mnuSave As System.Windows.Forms.MenuItem
        Private WithEvents mnuOpen As System.Windows.Forms.MenuItem
        Private WithEvents mnuNew As System.Windows.Forms.MenuItem

        Private Structure displaytransform
            Dim Width As Integer
            Dim Height As Integer
            Dim X As Integer
            Dim Y As Integer
            Dim xscalefactor As Double
            Dim yscalefactor As Double
        End Structure
        Public Enum fileType
            mi
            mask
            startDepth
            targetDepth
        End Enum
        Dim display As Point

        Public inputFile As fileType

        Private mnuFile As System.Windows.Forms.MenuItem
        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private myReader As StringReader
        Private blnSaveChkFlag, fileloaded, depthok, model_run_success, dynjeton, vscaling, toolpathshown As Boolean
        'Public startSurfaceOK, targetSurfaceOK As Boolean
        Dim depthfile, lastrowfound, firstrowfound, startlocationfound As Boolean
        Dim machine_name_found, ccompfound As Boolean
        Public nccode As New ArrayList
        Dim nclines() As String
        Dim filename, shortfilename, ncfilename, dxffilename, infofilename, surfacefilename, targetfilename As String
        Dim shortinfofilename, ncmodelfilename, shortstarttargetfilename, shorttargetfilename, shortMiFileName, shortMaskFileName As String
        Dim starttargetfilename, toolpathfilename, temptargetfilename, miFileName, maskFileName As String

        Dim zoomextents As displaytransform
        Dim zoomwindow As displaytransform
        Dim finaltrans As displaytransform
        Dim fittopage As displaytransform
        Dim nozoom As displaytransform
        Dim pagedisplay As displaytransform
        Dim screendisplay As displaytransform

        Dim xsectpoint0x, xsectpoint0y, xsectpoint1x, xsectpoint1y, x0, y0, x1, y1 As Integer
        Dim xsectactive, xsectiondrawn As Boolean
        Dim pic2xscale, pic2yscale, pic2scale As Double
        Dim xsectioncount, pic2yoffset As Integer
        Dim zoomactive, crossactive, runmodelstart As Boolean
        Dim depthmap, frmap As Boolean
        Dim zoomendx, zoomendy, zoomstartx, zoomstarty As Integer

        Dim oldx, oldy As Integer
        Dim dragging, panactive As Boolean

        Dim sbplabel() As String = {"Time: ", "Status: ", "Start: ", "Target: ", "Parm:", "Mask:", "MI:"}
        Dim sb0txtout, sb1txtout, sb2txtout, sb3txtout, sb4txtout As String

        Dim starttime, finishtime As System.DateTime
        Dim elapsedtime As System.TimeSpan

        Dim parminfo As New parminput
        Dim ifirstrow, istart, ilastrow, istartrow, icommentcount, ilength As Integer

        Dim stuserdir, stexedir, stdefdir As String
        Private d As Double


        Private pensize, pictxmid, pictymid As Integer
        Private bit As Bitmap
        'Private g, gtemp As Graphics
        Private gtemp2, img As Image
        Private bluepen As Pen = New Pen(Color.Blue, 1)
        Private greenpen As Pen = New Pen(Color.LawnGreen, 1)
        Private redpen As Pen = New Pen(Color.Red, 1)
        Private yellowpen As Pen = New Pen(Color.Yellow, 1)
        Private blackpen As Pen = New Pen(Color.Black, 1)
        Dim dashpen As Pen = New Pen(Color.Black, 1)

        Private txbrush As TextureBrush

        Private blueBrush As New SolidBrush(Color.FromArgb(0, 0, 255))
        Private blueGreenBrush As New SolidBrush(Color.FromArgb(0, 160, 160))
        Private greenBrush As New SolidBrush(Color.FromArgb(0, 255, 0))
        Private greenYellowBrush As New SolidBrush(Color.FromArgb(128, 255, 0))
        Private yellowBrush As New SolidBrush(Color.FromArgb(255, 255, 0))
        Private orangeBrush As New SolidBrush(Color.FromArgb(255, 128, 0))
        Private redBrush As New SolidBrush(Color.FromArgb(255, 0, 0))

        Private blackbrush As New SolidBrush(Color.Black)
        Private whitebrush As New SolidBrush(Color.White)

        Private g1brsh As New SolidBrush(Color.AntiqueWhite)
        Private g2brsh As New SolidBrush(Color.LightGray)
        Private g3brsh As New SolidBrush(Color.Gray)
        Private g4brsh As New SolidBrush(Color.WhiteSmoke)


        Dim thd As Thread
#Region " Windows Form Designer generated code "
        Public Sub New()
            InitializeComponent()
            stexedir = Path.GetDirectoryName(Application.ExecutablePath)
            stuserdir = stexedir + Path.DirectorySeparatorChar + "user"
            stdefdir = stexedir + Path.DirectorySeparatorChar + "defaults"
            'Me.mnuconstd.Checked = True

            targetsurfacetype = surfacetype.constant
            startsurfacetype = surfacetype.constant
            maskSurfaceType = surfacetype.constant
            miSurfaceType = surfacetype.constant

            startSurfaceOK = False
            targetSurfaceOK = False
            maskSurfaceOK = False
            miSurfaceOK = False

            Me.mnuconstantstartdepth.Checked = True
            Me.mnuconstd.Checked = True
            Me.mnuNoMask.Checked = True
            Me.mnuConstantMi.Checked = True

            Me.pan.Enabled = False
            Me.zoom.Enabled = False
            Me.zoomext.Enabled = False
            Me.crossh.Enabled = False
            Me.PictureBox1.Enabled = False
            Me.xsection.Enabled = False
            Me.PictureBox2.Enabled = False


            setcomponentlocations()

            GetSettings() 'Get Default Setting
        End Sub 'New



        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose

        Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
        Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
        Friend WithEvents runinfo As System.Windows.Forms.GroupBox
        Friend WithEvents curiter As System.Windows.Forms.TextBox
        Friend WithEvents iterationnumber As System.Windows.Forms.TextBox
        Friend WithEvents runnumber As System.Windows.Forms.TextBox
        Friend WithEvents currun As System.Windows.Forms.TextBox
        Friend WithEvents depthx As System.Windows.Forms.TextBox
        Friend WithEvents curdepth As System.Windows.Forms.TextBox
        Friend WithEvents depthy As System.Windows.Forms.TextBox
        Friend WithEvents outputoptions As System.Windows.Forms.GroupBox
        Friend WithEvents labeliteration As System.Windows.Forms.Label
        Friend WithEvents labelrun As System.Windows.Forms.Label
        Friend WithEvents labeldepth As System.Windows.Forms.Label
        Friend WithEvents label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents mnuinfo As System.Windows.Forms.MenuItem
        Friend WithEvents mnutest As System.Windows.Forms.MenuItem
        Friend WithEvents mnuman As System.Windows.Forms.MenuItem
        Friend WithEvents mnuconstd As System.Windows.Forms.MenuItem
        Friend WithEvents mnudxfin As System.Windows.Forms.MenuItem
        Friend WithEvents mnu2dpts As System.Windows.Forms.MenuItem
        Friend WithEvents curmrr As System.Windows.Forms.TextBox
        Friend WithEvents Runmodel As System.Windows.Forms.Button
        Friend WithEvents ThePrintDocument As System.Drawing.Printing.PrintDocument
        Friend WithEvents Richtextbox1 As System.Windows.Forms.RichTextBox
        Friend WithEvents stopmodel As System.Windows.Forms.Button
        Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents depthn As System.Windows.Forms.TextBox
        Friend WithEvents mnureplacefeedrates As System.Windows.Forms.MenuItem
        Friend WithEvents mnudefsettings As System.Windows.Forms.MenuItem
        Private WithEvents saveFileDialog As System.Windows.Forms.SaveFileDialog
        Private WithEvents openFileDialog As System.Windows.Forms.OpenFileDialog
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents mnuncdxf As System.Windows.Forms.MenuItem
        Friend WithEvents maxfeedrate As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents maxdfeedrate As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
        Friend WithEvents mnusaveparms As System.Windows.Forms.MenuItem
        Friend WithEvents mnusavedxfsurf As System.Windows.Forms.MenuItem
        Friend WithEvents mnusavecsvsurf As System.Windows.Forms.MenuItem
        Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents mnudxfpoints As System.Windows.Forms.MenuItem
        Friend WithEvents Intolerance As System.Windows.Forms.PictureBox
        Friend WithEvents intoler As System.Windows.Forms.TextBox
        Friend WithEvents pct_tooshallow As System.Windows.Forms.PictureBox
        Friend WithEvents pcttoodeep As System.Windows.Forms.PictureBox
        Friend WithEvents pctthrupart As System.Windows.Forms.PictureBox
        Friend WithEvents tooshal As System.Windows.Forms.TextBox
        Friend WithEvents toodeep As System.Windows.Forms.TextBox
        Friend WithEvents thrupart As System.Windows.Forms.TextBox
        Friend WithEvents mnudynjetonoff As System.Windows.Forms.MenuItem
        Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
        Friend WithEvents ctxcopy As System.Windows.Forms.MenuItem
        Friend WithEvents ctxcut As System.Windows.Forms.MenuItem
        Friend WithEvents ctxpaste As System.Windows.Forms.MenuItem
        Friend WithEvents ctxdelete As System.Windows.Forms.MenuItem
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents mnuscanfile As System.Windows.Forms.MenuItem
        Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
        Friend WithEvents ctxdepthdisplay As System.Windows.Forms.MenuItem
        Friend WithEvents mnuprintpic As System.Windows.Forms.MenuItem
        Friend WithEvents PrintDocument2 As System.Drawing.Printing.PrintDocument
        Friend WithEvents ctxtoolpath As System.Windows.Forms.MenuItem
        Friend WithEvents zoom As System.Windows.Forms.Button
        Friend WithEvents zoomext As System.Windows.Forms.Button
        Friend WithEvents pan As System.Windows.Forms.Button
        Friend WithEvents crossh As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents xsection As System.Windows.Forms.Button
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
        Friend WithEvents ContextMenu3 As System.Windows.Forms.ContextMenu
        Friend WithEvents ctx1scale As System.Windows.Forms.MenuItem
        Friend WithEvents ctxstretchscale As System.Windows.Forms.MenuItem
        Friend WithEvents txtxsectdepth As System.Windows.Forms.TextBox
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents mnurescalefeedrates As System.Windows.Forms.MenuItem
        Friend WithEvents mnuoptions As System.Windows.Forms.MenuItem
        Friend WithEvents mnuhelp As System.Windows.Forms.MenuItem
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txt_timetomachine As System.Windows.Forms.TextBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
        Friend WithEvents mnuconstantstartdepth As System.Windows.Forms.MenuItem
        Friend WithEvents mnudxfregionstartdepth As System.Windows.Forms.MenuItem
        Friend WithEvents mnucsvstartdepth As System.Windows.Forms.MenuItem
        Friend WithEvents mnudxfpointstartdepth As System.Windows.Forms.MenuItem
        Friend WithEvents sbpstatus As System.Windows.Forms.StatusBarPanel
        Friend WithEvents startdepth As System.Windows.Forms.StatusBarPanel
        Friend WithEvents targetdepth As System.Windows.Forms.StatusBarPanel
        Friend WithEvents sbfrm1 As System.Windows.Forms.StatusBar
        Friend WithEvents sbpstarttime As System.Windows.Forms.StatusBarPanel
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents txtxsectpos As System.Windows.Forms.TextBox
        Friend WithEvents parmfilename As System.Windows.Forms.StatusBarPanel
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents txtdepthatcursor As System.Windows.Forms.TextBox
        Friend WithEvents txtcursory As System.Windows.Forms.TextBox
        Friend WithEvents txtcursorx As System.Windows.Forms.TextBox
        Friend WithEvents txtcursorf As System.Windows.Forms.TextBox
        Friend WithEvents txtcursorn As System.Windows.Forms.TextBox
        Friend WithEvents txtcursordnom As System.Windows.Forms.TextBox
        Friend WithEvents txtcursormi As System.Windows.Forms.TextBox
        Friend WithEvents ctxdepthmap As System.Windows.Forms.MenuItem
        Friend WithEvents ctxfrmap As System.Windows.Forms.MenuItem
        Friend WithEvents ctxjumpnc As System.Windows.Forms.MenuItem
        Friend WithEvents runAsIs As System.Windows.Forms.RadioButton
        Friend WithEvents newfeedoption As System.Windows.Forms.RadioButton
        Friend WithEvents depthstop As System.Windows.Forms.RadioButton
        Friend WithEvents mrradjust As System.Windows.Forms.RadioButton
        Friend WithEvents mnuRenumberFile As System.Windows.Forms.MenuItem
        Friend WithEvents txtDepthStarting As System.Windows.Forms.TextBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
        Friend WithEvents mnuDxfMaskPontFile As System.Windows.Forms.MenuItem
        Friend WithEvents txtCursorMask As System.Windows.Forms.TextBox
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents mnuNoMask As System.Windows.Forms.MenuItem
        Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
        Friend WithEvents mnuConstantMi As System.Windows.Forms.MenuItem
        Friend WithEvents mnuCsvMi As System.Windows.Forms.MenuItem
        Friend WithEvents mnuDxfMi As System.Windows.Forms.MenuItem
        Friend WithEvents mask As System.Windows.Forms.StatusBarPanel
        Friend WithEvents MI As System.Windows.Forms.StatusBarPanel
        Friend WithEvents newMiOption As System.Windows.Forms.RadioButton
        Friend WithEvents minFeedrate As System.Windows.Forms.TextBox
        Friend WithEvents Label24 As System.Windows.Forms.Label




        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
            Me.mnuPaste = New System.Windows.Forms.MenuItem
            Me.colorDialog1 = New System.Windows.Forms.ColorDialog
            Me.mnuSaveAs = New System.Windows.Forms.MenuItem
            Me.mnuNew = New System.Windows.Forms.MenuItem
            Me.mnuAbout = New System.Windows.Forms.MenuItem
            Me.pageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
            Me.mnuCopy = New System.Windows.Forms.MenuItem
            Me.mnuExit = New System.Windows.Forms.MenuItem
            Me.mnuUndo = New System.Windows.Forms.MenuItem
            Me.menuItem12 = New System.Windows.Forms.MenuItem
            Me.mnuPrint = New System.Windows.Forms.MenuItem
            Me.mnuFile = New System.Windows.Forms.MenuItem
            Me.mnuOpen = New System.Windows.Forms.MenuItem
            Me.mnuSave = New System.Windows.Forms.MenuItem
            Me.MenuItem13 = New System.Windows.Forms.MenuItem
            Me.mnusaveparms = New System.Windows.Forms.MenuItem
            Me.mnusavedxfsurf = New System.Windows.Forms.MenuItem
            Me.mnusavecsvsurf = New System.Windows.Forms.MenuItem
            Me.menuItem9 = New System.Windows.Forms.MenuItem
            Me.mnuPageSetUp = New System.Windows.Forms.MenuItem
            Me.mnuprintpic = New System.Windows.Forms.MenuItem
            Me.mnuCut = New System.Windows.Forms.MenuItem
            Me.menuItem7 = New System.Windows.Forms.MenuItem
            Me.mnuhelp = New System.Windows.Forms.MenuItem
            Me.menuItem6 = New System.Windows.Forms.MenuItem
            Me.mnurescalefeedrates = New System.Windows.Forms.MenuItem
            Me.mnureplacefeedrates = New System.Windows.Forms.MenuItem
            Me.mnuncdxf = New System.Windows.Forms.MenuItem
            Me.mnudynjetonoff = New System.Windows.Forms.MenuItem
            Me.mnuscanfile = New System.Windows.Forms.MenuItem
            Me.mnuRenumberFile = New System.Windows.Forms.MenuItem
            Me.mnuoptions = New System.Windows.Forms.MenuItem
            Me.mnuSelectAll = New System.Windows.Forms.MenuItem
            Me.menuItem2 = New System.Windows.Forms.MenuItem
            Me.menuItem5 = New System.Windows.Forms.MenuItem
            Me.saveFileDialog = New System.Windows.Forms.SaveFileDialog
            Me.mnuDelete = New System.Windows.Forms.MenuItem
            Me.mnuEdit = New System.Windows.Forms.MenuItem
            Me.mainMenu1 = New System.Windows.Forms.MainMenu
            Me.MenuItem1 = New System.Windows.Forms.MenuItem
            Me.mnuinfo = New System.Windows.Forms.MenuItem
            Me.mnutest = New System.Windows.Forms.MenuItem
            Me.mnuman = New System.Windows.Forms.MenuItem
            Me.mnudefsettings = New System.Windows.Forms.MenuItem
            Me.MenuItem8 = New System.Windows.Forms.MenuItem
            Me.mnuconstd = New System.Windows.Forms.MenuItem
            Me.mnudxfin = New System.Windows.Forms.MenuItem
            Me.mnu2dpts = New System.Windows.Forms.MenuItem
            Me.mnudxfpoints = New System.Windows.Forms.MenuItem
            Me.MenuItem3 = New System.Windows.Forms.MenuItem
            Me.mnuconstantstartdepth = New System.Windows.Forms.MenuItem
            Me.mnudxfregionstartdepth = New System.Windows.Forms.MenuItem
            Me.mnucsvstartdepth = New System.Windows.Forms.MenuItem
            Me.mnudxfpointstartdepth = New System.Windows.Forms.MenuItem
            Me.MenuItem10 = New System.Windows.Forms.MenuItem
            Me.mnuConstantMi = New System.Windows.Forms.MenuItem
            Me.mnuCsvMi = New System.Windows.Forms.MenuItem
            Me.mnuDxfMi = New System.Windows.Forms.MenuItem
            Me.MenuItem4 = New System.Windows.Forms.MenuItem
            Me.mnuNoMask = New System.Windows.Forms.MenuItem
            Me.mnuDxfMaskPontFile = New System.Windows.Forms.MenuItem
            Me.fontDialog1 = New System.Windows.Forms.FontDialog
            Me.openFileDialog = New System.Windows.Forms.OpenFileDialog
            Me.printDialog1 = New System.Windows.Forms.PrintDialog
            Me.runinfo = New System.Windows.Forms.GroupBox
            Me.label1 = New System.Windows.Forms.Label
            Me.labeliteration = New System.Windows.Forms.Label
            Me.curiter = New System.Windows.Forms.TextBox
            Me.iterationnumber = New System.Windows.Forms.TextBox
            Me.runnumber = New System.Windows.Forms.TextBox
            Me.currun = New System.Windows.Forms.TextBox
            Me.depthx = New System.Windows.Forms.TextBox
            Me.curdepth = New System.Windows.Forms.TextBox
            Me.depthy = New System.Windows.Forms.TextBox
            Me.curmrr = New System.Windows.Forms.TextBox
            Me.labelrun = New System.Windows.Forms.Label
            Me.labeldepth = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.depthn = New System.Windows.Forms.TextBox
            Me.Label8 = New System.Windows.Forms.Label
            Me.outputoptions = New System.Windows.Forms.GroupBox
            Me.runAsIs = New System.Windows.Forms.RadioButton
            Me.newfeedoption = New System.Windows.Forms.RadioButton
            Me.depthstop = New System.Windows.Forms.RadioButton
            Me.mrradjust = New System.Windows.Forms.RadioButton
            Me.Runmodel = New System.Windows.Forms.Button
            Me.stopmodel = New System.Windows.Forms.Button
            Me.ThePrintDocument = New System.Drawing.Printing.PrintDocument
            Me.Richtextbox1 = New System.Windows.Forms.RichTextBox
            Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
            Me.ctxcopy = New System.Windows.Forms.MenuItem
            Me.ctxcut = New System.Windows.Forms.MenuItem
            Me.ctxpaste = New System.Windows.Forms.MenuItem
            Me.ctxdelete = New System.Windows.Forms.MenuItem
            Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
            Me.ctxdepthdisplay = New System.Windows.Forms.MenuItem
            Me.ctxtoolpath = New System.Windows.Forms.MenuItem
            Me.ctxdepthmap = New System.Windows.Forms.MenuItem
            Me.ctxfrmap = New System.Windows.Forms.MenuItem
            Me.ctxjumpnc = New System.Windows.Forms.MenuItem
            Me.txtdepthatcursor = New System.Windows.Forms.TextBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.txtcursory = New System.Windows.Forms.TextBox
            Me.txtcursorx = New System.Windows.Forms.TextBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.Label10 = New System.Windows.Forms.Label
            Me.maxfeedrate = New System.Windows.Forms.TextBox
            Me.Label11 = New System.Windows.Forms.Label
            Me.maxdfeedrate = New System.Windows.Forms.TextBox
            Me.Label12 = New System.Windows.Forms.Label
            Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.Label15 = New System.Windows.Forms.Label
            Me.tooshal = New System.Windows.Forms.TextBox
            Me.pct_tooshallow = New System.Windows.Forms.PictureBox
            Me.Label13 = New System.Windows.Forms.Label
            Me.txtcursorf = New System.Windows.Forms.TextBox
            Me.txtcursorn = New System.Windows.Forms.TextBox
            Me.Label14 = New System.Windows.Forms.Label
            Me.Intolerance = New System.Windows.Forms.PictureBox
            Me.pcttoodeep = New System.Windows.Forms.PictureBox
            Me.pctthrupart = New System.Windows.Forms.PictureBox
            Me.intoler = New System.Windows.Forms.TextBox
            Me.toodeep = New System.Windows.Forms.TextBox
            Me.thrupart = New System.Windows.Forms.TextBox
            Me.Label16 = New System.Windows.Forms.Label
            Me.txtcursordnom = New System.Windows.Forms.TextBox
            Me.Label19 = New System.Windows.Forms.Label
            Me.txtcursormi = New System.Windows.Forms.TextBox
            Me.Label21 = New System.Windows.Forms.Label
            Me.txtDepthStarting = New System.Windows.Forms.TextBox
            Me.Label22 = New System.Windows.Forms.Label
            Me.txtCursorMask = New System.Windows.Forms.TextBox
            Me.Label23 = New System.Windows.Forms.Label
            Me.PictureBox2 = New System.Windows.Forms.PictureBox
            Me.ContextMenu3 = New System.Windows.Forms.ContextMenu
            Me.ctx1scale = New System.Windows.Forms.MenuItem
            Me.ctxstretchscale = New System.Windows.Forms.MenuItem
            Me.txt_timetomachine = New System.Windows.Forms.TextBox
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.zoom = New System.Windows.Forms.Button
            Me.zoomext = New System.Windows.Forms.Button
            Me.pan = New System.Windows.Forms.Button
            Me.crossh = New System.Windows.Forms.Button
            Me.xsection = New System.Windows.Forms.Button
            Me.PrintDocument2 = New System.Drawing.Printing.PrintDocument
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.txtxsectdepth = New System.Windows.Forms.TextBox
            Me.Label17 = New System.Windows.Forms.Label
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.Label20 = New System.Windows.Forms.Label
            Me.txtxsectpos = New System.Windows.Forms.TextBox
            Me.Label18 = New System.Windows.Forms.Label
            Me.Panel3 = New System.Windows.Forms.Panel
            Me.sbfrm1 = New System.Windows.Forms.StatusBar
            Me.sbpstarttime = New System.Windows.Forms.StatusBarPanel
            Me.sbpstatus = New System.Windows.Forms.StatusBarPanel
            Me.startdepth = New System.Windows.Forms.StatusBarPanel
            Me.targetdepth = New System.Windows.Forms.StatusBarPanel
            Me.parmfilename = New System.Windows.Forms.StatusBarPanel
            Me.mask = New System.Windows.Forms.StatusBarPanel
            Me.MI = New System.Windows.Forms.StatusBarPanel
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.newMiOption = New System.Windows.Forms.RadioButton
            Me.minFeedrate = New System.Windows.Forms.TextBox
            Me.Label24 = New System.Windows.Forms.Label
            Me.runinfo.SuspendLayout()
            Me.outputoptions.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.sbpstarttime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.sbpstatus, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startdepth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.targetdepth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.parmfilename, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mask, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MI, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mnuPaste
            '
            Me.mnuPaste.Index = 4
            Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
            Me.mnuPaste.Text = "&Paste"
            '
            'mnuSaveAs
            '
            Me.mnuSaveAs.Index = 4
            Me.mnuSaveAs.Text = "Save &As..."
            '
            'mnuNew
            '
            Me.mnuNew.Index = 0
            Me.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN
            Me.mnuNew.Text = "&New"
            '
            'mnuAbout
            '
            Me.mnuAbout.Index = 1
            Me.mnuAbout.Text = "&About"
            '
            'mnuCopy
            '
            Me.mnuCopy.Index = 3
            Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
            Me.mnuCopy.Text = "&Copy"
            '
            'mnuExit
            '
            Me.mnuExit.Index = 10
            Me.mnuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4
            Me.mnuExit.Text = "E&xit"
            '
            'mnuUndo
            '
            Me.mnuUndo.Index = 0
            Me.mnuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
            Me.mnuUndo.Text = "&Undo"
            '
            'menuItem12
            '
            Me.menuItem12.Index = 9
            Me.menuItem12.Text = "-"
            '
            'mnuPrint
            '
            Me.mnuPrint.Index = 7
            Me.mnuPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP
            Me.mnuPrint.Text = "&Print NC File"
            '
            'mnuFile
            '
            Me.mnuFile.Index = 0
            Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuOpen, Me.mnuSave, Me.MenuItem13, Me.mnuSaveAs, Me.menuItem9, Me.mnuPageSetUp, Me.mnuPrint, Me.mnuprintpic, Me.menuItem12, Me.mnuExit})
            Me.mnuFile.Text = "&File"
            '
            'mnuOpen
            '
            Me.mnuOpen.Index = 1
            Me.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me.mnuOpen.Text = "&Open..."
            '
            'mnuSave
            '
            Me.mnuSave.Index = 2
            Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me.mnuSave.Text = "&Save NC File"
            '
            'MenuItem13
            '
            Me.MenuItem13.Index = 3
            Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnusaveparms, Me.mnusavedxfsurf, Me.mnusavecsvsurf})
            Me.MenuItem13.Text = "Save Other"
            '
            'mnusaveparms
            '
            Me.mnusaveparms.Index = 0
            Me.mnusaveparms.Text = "Parameter File"
            '
            'mnusavedxfsurf
            '
            Me.mnusavedxfsurf.Index = 1
            Me.mnusavedxfsurf.Text = "DXF Surface File"
            '
            'mnusavecsvsurf
            '
            Me.mnusavecsvsurf.Index = 2
            Me.mnusavecsvsurf.Text = "CSV Surface File"
            '
            'menuItem9
            '
            Me.menuItem9.Index = 5
            Me.menuItem9.Text = "-"
            '
            'mnuPageSetUp
            '
            Me.mnuPageSetUp.Index = 6
            Me.mnuPageSetUp.Text = "Page Se&tup..."
            '
            'mnuprintpic
            '
            Me.mnuprintpic.Index = 8
            Me.mnuprintpic.Text = "Print Picture"
            '
            'mnuCut
            '
            Me.mnuCut.Index = 2
            Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
            Me.mnuCut.Text = "C&ut"
            '
            'menuItem7
            '
            Me.menuItem7.Index = 8
            Me.menuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuhelp, Me.mnuAbout})
            Me.menuItem7.Text = "&Help"
            '
            'mnuhelp
            '
            Me.mnuhelp.Index = 0
            Me.mnuhelp.Text = "Help"
            '
            'menuItem6
            '
            Me.menuItem6.Index = 2
            Me.menuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnurescalefeedrates, Me.mnureplacefeedrates, Me.mnuncdxf, Me.mnudynjetonoff, Me.mnuscanfile, Me.mnuRenumberFile, Me.mnuoptions})
            Me.menuItem6.Text = "&Tools"
            '
            'mnurescalefeedrates
            '
            Me.mnurescalefeedrates.Index = 0
            Me.mnurescalefeedrates.Text = "Rescale Feedrates"
            '
            'mnureplacefeedrates
            '
            Me.mnureplacefeedrates.Index = 1
            Me.mnureplacefeedrates.Text = "Replace Feedrates"
            '
            'mnuncdxf
            '
            Me.mnuncdxf.Index = 2
            Me.mnuncdxf.Text = "Create DXF with Line Numbers"
            '
            'mnudynjetonoff
            '
            Me.mnudynjetonoff.Index = 3
            Me.mnudynjetonoff.Text = "Add on-the-fly JETON/OFF"
            '
            'mnuscanfile
            '
            Me.mnuscanfile.Index = 4
            Me.mnuscanfile.Text = "Scan file for Syntax"
            '
            'mnuRenumberFile
            '
            Me.mnuRenumberFile.Index = 5
            Me.mnuRenumberFile.Text = "Renumber File"
            '
            'mnuoptions
            '
            Me.mnuoptions.Index = 6
            Me.mnuoptions.Text = "Preferences..."
            '
            'mnuSelectAll
            '
            Me.mnuSelectAll.Index = 7
            Me.mnuSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
            Me.mnuSelectAll.Text = "Select &All"
            '
            'menuItem2
            '
            Me.menuItem2.Index = 1
            Me.menuItem2.Text = "-"
            '
            'menuItem5
            '
            Me.menuItem5.Index = 6
            Me.menuItem5.Text = "-"
            '
            'saveFileDialog
            '
            Me.saveFileDialog.DefaultExt = "ncm"
            Me.saveFileDialog.FileName = "doc1.ncm"
            Me.saveFileDialog.Filter = "Text files (*.*)|*.*"
            Me.saveFileDialog.RestoreDirectory = True
            '
            'mnuDelete
            '
            Me.mnuDelete.Index = 5
            Me.mnuDelete.Shortcut = System.Windows.Forms.Shortcut.Del
            Me.mnuDelete.Text = "De&lete"
            '
            'mnuEdit
            '
            Me.mnuEdit.Index = 1
            Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuUndo, Me.menuItem2, Me.mnuCut, Me.mnuCopy, Me.mnuPaste, Me.mnuDelete, Me.menuItem5, Me.mnuSelectAll})
            Me.mnuEdit.Text = "&Edit"
            '
            'mainMenu1
            '
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.menuItem6, Me.MenuItem1, Me.MenuItem8, Me.MenuItem3, Me.MenuItem10, Me.MenuItem4, Me.menuItem7})
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 3
            Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuinfo, Me.mnutest, Me.mnuman, Me.mnudefsettings})
            Me.MenuItem1.Text = "Parameter &Input"
            '
            'mnuinfo
            '
            Me.mnuinfo.Index = 0
            Me.mnuinfo.Text = "Info File"
            '
            'mnutest
            '
            Me.mnutest.Index = 1
            Me.mnutest.Text = "Test Groove"
            '
            'mnuman
            '
            Me.mnuman.Index = 2
            Me.mnuman.Text = "Manual Entry"
            '
            'mnudefsettings
            '
            Me.mnudefsettings.Index = 3
            Me.mnudefsettings.Text = "Default Settings"
            '
            'MenuItem8
            '
            Me.MenuItem8.Index = 4
            Me.MenuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuconstd, Me.mnudxfin, Me.mnu2dpts, Me.mnudxfpoints})
            Me.MenuItem8.Text = "&Target Depth"
            '
            'mnuconstd
            '
            Me.mnuconstd.Index = 0
            Me.mnuconstd.RadioCheck = True
            Me.mnuconstd.Text = "Constant Depth"
            '
            'mnudxfin
            '
            Me.mnudxfin.Index = 1
            Me.mnudxfin.RadioCheck = True
            Me.mnudxfin.Text = "DXF Region File"
            '
            'mnu2dpts
            '
            Me.mnu2dpts.Index = 2
            Me.mnu2dpts.RadioCheck = True
            Me.mnu2dpts.Text = "CSV Surface Point File"
            '
            'mnudxfpoints
            '
            Me.mnudxfpoints.Index = 3
            Me.mnudxfpoints.Text = "DXF Surface Point File"
            '
            'MenuItem3
            '
            Me.MenuItem3.Index = 5
            Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuconstantstartdepth, Me.mnudxfregionstartdepth, Me.mnucsvstartdepth, Me.mnudxfpointstartdepth})
            Me.MenuItem3.Text = "Starting Depth"
            '
            'mnuconstantstartdepth
            '
            Me.mnuconstantstartdepth.Index = 0
            Me.mnuconstantstartdepth.RadioCheck = True
            Me.mnuconstantstartdepth.Text = "Constant Z=0"
            '
            'mnudxfregionstartdepth
            '
            Me.mnudxfregionstartdepth.Index = 1
            Me.mnudxfregionstartdepth.Text = "DXF Region File"
            '
            'mnucsvstartdepth
            '
            Me.mnucsvstartdepth.Index = 2
            Me.mnucsvstartdepth.Text = "CSV Surface Point File"
            '
            'mnudxfpointstartdepth
            '
            Me.mnudxfpointstartdepth.Index = 3
            Me.mnudxfpointstartdepth.Text = "DXF Surface Point File"
            '
            'MenuItem10
            '
            Me.MenuItem10.Index = 6
            Me.MenuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConstantMi, Me.mnuCsvMi, Me.mnuDxfMi})
            Me.MenuItem10.Text = "MI Input"
            '
            'mnuConstantMi
            '
            Me.mnuConstantMi.Index = 0
            Me.mnuConstantMi.RadioCheck = True
            Me.mnuConstantMi.Text = "Constant MI=1"
            '
            'mnuCsvMi
            '
            Me.mnuCsvMi.Index = 1
            Me.mnuCsvMi.RadioCheck = True
            Me.mnuCsvMi.Text = "CSV Point File"
            '
            'mnuDxfMi
            '
            Me.mnuDxfMi.Index = 2
            Me.mnuDxfMi.RadioCheck = True
            Me.mnuDxfMi.Text = "DXF Point File"
            '
            'MenuItem4
            '
            Me.MenuItem4.Index = 7
            Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNoMask, Me.mnuDxfMaskPontFile})
            Me.MenuItem4.Text = "Mask Input"
            '
            'mnuNoMask
            '
            Me.mnuNoMask.Index = 0
            Me.mnuNoMask.RadioCheck = True
            Me.mnuNoMask.Text = "No Mask"
            '
            'mnuDxfMaskPontFile
            '
            Me.mnuDxfMaskPontFile.Index = 1
            Me.mnuDxfMaskPontFile.RadioCheck = True
            Me.mnuDxfMaskPontFile.Text = "DXF Surface Point File"
            '
            'openFileDialog
            '
            Me.openFileDialog.RestoreDirectory = True
            Me.openFileDialog.Title = "Open File"
            '
            'printDialog1
            '
            Me.printDialog1.AllowSelection = True
            Me.printDialog1.AllowSomePages = True
            '
            'runinfo
            '
            Me.runinfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.runinfo.Controls.Add(Me.label1)
            Me.runinfo.Controls.Add(Me.labeliteration)
            Me.runinfo.Controls.Add(Me.curiter)
            Me.runinfo.Controls.Add(Me.iterationnumber)
            Me.runinfo.Controls.Add(Me.runnumber)
            Me.runinfo.Controls.Add(Me.currun)
            Me.runinfo.Controls.Add(Me.depthx)
            Me.runinfo.Controls.Add(Me.curdepth)
            Me.runinfo.Controls.Add(Me.depthy)
            Me.runinfo.Controls.Add(Me.curmrr)
            Me.runinfo.Controls.Add(Me.labelrun)
            Me.runinfo.Controls.Add(Me.labeldepth)
            Me.runinfo.Controls.Add(Me.Label2)
            Me.runinfo.Controls.Add(Me.Label3)
            Me.runinfo.Controls.Add(Me.Label4)
            Me.runinfo.Controls.Add(Me.Label5)
            Me.runinfo.Controls.Add(Me.Label6)
            Me.runinfo.Controls.Add(Me.depthn)
            Me.runinfo.Controls.Add(Me.Label8)
            Me.runinfo.Location = New System.Drawing.Point(24, 331)
            Me.runinfo.Name = "runinfo"
            Me.runinfo.Size = New System.Drawing.Size(200, 225)
            Me.runinfo.TabIndex = 1
            Me.runinfo.TabStop = False
            Me.runinfo.Text = "Run Status"
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(112, 24)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(14, 16)
            Me.label1.TabIndex = 2
            Me.label1.Text = "of"
            '
            'labeliteration
            '
            Me.labeliteration.AutoSize = True
            Me.labeliteration.Location = New System.Drawing.Point(8, 16)
            Me.labeliteration.Name = "labeliteration"
            Me.labeliteration.Size = New System.Drawing.Size(45, 16)
            Me.labeliteration.TabIndex = 1
            Me.labeliteration.Text = "Iteration"
            Me.labeliteration.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'curiter
            '
            Me.curiter.Location = New System.Drawing.Point(64, 16)
            Me.curiter.Name = "curiter"
            Me.curiter.ReadOnly = True
            Me.curiter.Size = New System.Drawing.Size(40, 20)
            Me.curiter.TabIndex = 0
            Me.curiter.Text = "0"
            '
            'iterationnumber
            '
            Me.HelpProvider1.SetHelpString(Me.iterationnumber, "Iterates model and uses new feedrates each time if New Feedrates selected")
            Me.iterationnumber.Location = New System.Drawing.Point(136, 16)
            Me.iterationnumber.Name = "iterationnumber"
            Me.HelpProvider1.SetShowHelp(Me.iterationnumber, True)
            Me.iterationnumber.Size = New System.Drawing.Size(40, 20)
            Me.iterationnumber.TabIndex = 1
            Me.iterationnumber.Text = "1"
            Me.ToolTip1.SetToolTip(Me.iterationnumber, "integer >=1")
            '
            'runnumber
            '
            Me.HelpProvider1.SetHelpString(Me.runnumber, "runs model multiple time to simulate multiple NC program runs")
            Me.runnumber.Location = New System.Drawing.Point(136, 48)
            Me.runnumber.Name = "runnumber"
            Me.HelpProvider1.SetShowHelp(Me.runnumber, True)
            Me.runnumber.Size = New System.Drawing.Size(40, 20)
            Me.runnumber.TabIndex = 2
            Me.runnumber.Text = "1"
            Me.ToolTip1.SetToolTip(Me.runnumber, ">0")
            '
            'currun
            '
            Me.currun.Location = New System.Drawing.Point(64, 48)
            Me.currun.Name = "currun"
            Me.currun.ReadOnly = True
            Me.currun.Size = New System.Drawing.Size(40, 20)
            Me.currun.TabIndex = 0
            Me.currun.Text = "0"
            '
            'depthx
            '
            Me.HelpProvider1.SetHelpString(Me.depthx, "X location of depth measurement used to adjust MRR value")
            Me.depthx.Location = New System.Drawing.Point(80, 112)
            Me.depthx.Name = "depthx"
            Me.HelpProvider1.SetShowHelp(Me.depthx, True)
            Me.depthx.Size = New System.Drawing.Size(40, 20)
            Me.depthx.TabIndex = 3
            Me.depthx.Text = "X"
            '
            'curdepth
            '
            Me.curdepth.Location = New System.Drawing.Point(112, 88)
            Me.curdepth.Name = "curdepth"
            Me.curdepth.ReadOnly = True
            Me.curdepth.Size = New System.Drawing.Size(48, 20)
            Me.curdepth.TabIndex = 0
            Me.curdepth.Text = "0.000"
            '
            'depthy
            '
            Me.HelpProvider1.SetHelpString(Me.depthy, "Y location of depth measurement used to adjust MRR value")
            Me.depthy.Location = New System.Drawing.Point(144, 112)
            Me.depthy.Name = "depthy"
            Me.HelpProvider1.SetShowHelp(Me.depthy, True)
            Me.depthy.Size = New System.Drawing.Size(40, 20)
            Me.depthy.TabIndex = 4
            Me.depthy.Text = "Y"
            '
            'curmrr
            '
            Me.curmrr.Location = New System.Drawing.Point(96, 192)
            Me.curmrr.Name = "curmrr"
            Me.curmrr.ReadOnly = True
            Me.curmrr.Size = New System.Drawing.Size(48, 20)
            Me.curmrr.TabIndex = 0
            Me.curmrr.Text = ""
            '
            'labelrun
            '
            Me.labelrun.AutoSize = True
            Me.labelrun.Location = New System.Drawing.Point(8, 48)
            Me.labelrun.Name = "labelrun"
            Me.labelrun.Size = New System.Drawing.Size(25, 16)
            Me.labelrun.TabIndex = 1
            Me.labelrun.Text = "Run"
            Me.labelrun.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'labeldepth
            '
            Me.labeldepth.AutoSize = True
            Me.labeldepth.Location = New System.Drawing.Point(32, 88)
            Me.labeldepth.Name = "labeldepth"
            Me.labeldepth.Size = New System.Drawing.Size(75, 16)
            Me.labeldepth.TabIndex = 1
            Me.labeldepth.Text = "Current Depth"
            Me.labeldepth.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(112, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(14, 16)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "of"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(64, 112)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(12, 16)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "X"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(40, 112)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(14, 16)
            Me.Label4.TabIndex = 1
            Me.Label4.Text = "at"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label5.Location = New System.Drawing.Point(128, 112)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(12, 16)
            Me.Label5.TabIndex = 1
            Me.Label5.Text = "Y"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(8, 192)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(71, 16)
            Me.Label6.TabIndex = 1
            Me.Label6.Text = "Current MRR"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'depthn
            '
            Me.HelpProvider1.SetHelpString(Me.depthn, "Enter NC line number for depth display used to adjust MRR value")
            Me.depthn.Location = New System.Drawing.Point(128, 144)
            Me.depthn.Name = "depthn"
            Me.HelpProvider1.SetShowHelp(Me.depthn, True)
            Me.depthn.Size = New System.Drawing.Size(40, 20)
            Me.depthn.TabIndex = 5
            Me.depthn.Text = ""
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(16, 144)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(112, 16)
            Me.Label8.TabIndex = 3
            Me.Label8.Text = "or midpoint of line N"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'outputoptions
            '
            Me.outputoptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.outputoptions.Controls.Add(Me.runAsIs)
            Me.outputoptions.Controls.Add(Me.newfeedoption)
            Me.outputoptions.Controls.Add(Me.depthstop)
            Me.outputoptions.Controls.Add(Me.mrradjust)
            Me.outputoptions.Controls.Add(Me.newMiOption)
            Me.outputoptions.Location = New System.Drawing.Point(245, 430)
            Me.outputoptions.Name = "outputoptions"
            Me.outputoptions.Size = New System.Drawing.Size(176, 145)
            Me.outputoptions.TabIndex = 2
            Me.outputoptions.TabStop = False
            Me.outputoptions.Text = "Output Options"
            '
            'runAsIs
            '
            Me.HelpProvider1.SetHelpString(Me.runAsIs, "Run NC file with no changes")
            Me.runAsIs.Location = New System.Drawing.Point(16, 16)
            Me.runAsIs.Name = "runAsIs"
            Me.HelpProvider1.SetShowHelp(Me.runAsIs, True)
            Me.runAsIs.TabIndex = 0
            Me.runAsIs.Text = "Run As Is"
            '
            'newfeedoption
            '
            Me.HelpProvider1.SetHelpString(Me.newfeedoption, "Adjust feed rates in file based on model depth")
            Me.newfeedoption.Location = New System.Drawing.Point(16, 40)
            Me.newfeedoption.Name = "newfeedoption"
            Me.HelpProvider1.SetShowHelp(Me.newfeedoption, True)
            Me.newfeedoption.TabIndex = 0
            Me.newfeedoption.Text = "New Feedrates"
            '
            'depthstop
            '
            Me.HelpProvider1.SetHelpString(Me.depthstop, "Stop model run when model reaches nominal depth")
            Me.depthstop.Location = New System.Drawing.Point(16, 96)
            Me.depthstop.Name = "depthstop"
            Me.HelpProvider1.SetShowHelp(Me.depthstop, True)
            Me.depthstop.Size = New System.Drawing.Size(144, 24)
            Me.depthstop.TabIndex = 0
            Me.depthstop.Text = "Stop at nominal depth"
            '
            'mrradjust
            '
            Me.HelpProvider1.SetHelpString(Me.mrradjust, "Adjust MRR in parameter file based on model depth")
            Me.mrradjust.Location = New System.Drawing.Point(16, 64)
            Me.mrradjust.Name = "mrradjust"
            Me.HelpProvider1.SetShowHelp(Me.mrradjust, True)
            Me.mrradjust.Size = New System.Drawing.Size(152, 32)
            Me.mrradjust.TabIndex = 0
            Me.mrradjust.Text = "Adjust MRR after each run"
            '
            'Runmodel
            '
            Me.Runmodel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Runmodel.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Runmodel.Enabled = False
            Me.Runmodel.Location = New System.Drawing.Point(475, 499)
            Me.Runmodel.Name = "Runmodel"
            Me.Runmodel.Size = New System.Drawing.Size(48, 32)
            Me.Runmodel.TabIndex = 12
            Me.Runmodel.Text = "Run Model"
            '
            'stopmodel
            '
            Me.stopmodel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.stopmodel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.stopmodel.Enabled = False
            Me.stopmodel.Location = New System.Drawing.Point(540, 499)
            Me.stopmodel.Name = "stopmodel"
            Me.stopmodel.Size = New System.Drawing.Size(48, 32)
            Me.stopmodel.TabIndex = 13
            Me.stopmodel.TabStop = False
            Me.stopmodel.Text = "Stop Model"
            '
            'ThePrintDocument
            '
            '
            'Richtextbox1
            '
            Me.Richtextbox1.AutoSize = True
            Me.Richtextbox1.AutoWordSelection = True
            Me.Richtextbox1.ContextMenu = Me.ContextMenu1
            Me.Richtextbox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Richtextbox1.Location = New System.Drawing.Point(0, 0)
            Me.Richtextbox1.Name = "Richtextbox1"
            Me.Richtextbox1.Size = New System.Drawing.Size(479, 260)
            Me.Richtextbox1.TabIndex = 4
            Me.Richtextbox1.Text = ""
            Me.Richtextbox1.WordWrap = False
            '
            'ContextMenu1
            '
            Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ctxcopy, Me.ctxcut, Me.ctxpaste, Me.ctxdelete})
            '
            'ctxcopy
            '
            Me.ctxcopy.Index = 0
            Me.ctxcopy.Text = "Copy"
            '
            'ctxcut
            '
            Me.ctxcut.Index = 1
            Me.ctxcut.Text = "Cut"
            '
            'ctxpaste
            '
            Me.ctxpaste.Index = 2
            Me.ctxpaste.Text = "Paste"
            '
            'ctxdelete
            '
            Me.ctxdelete.Index = 3
            Me.ctxdelete.Text = "Delete"
            '
            'ProgressBar1
            '
            Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ProgressBar1.Location = New System.Drawing.Point(465, 539)
            Me.ProgressBar1.Name = "ProgressBar1"
            Me.ProgressBar1.Size = New System.Drawing.Size(144, 16)
            Me.ProgressBar1.TabIndex = 6
            '
            'PictureBox1
            '
            Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PictureBox1.ContextMenu = Me.ContextMenu2
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross
            Me.HelpProvider1.SetHelpString(Me.PictureBox1, "Displays color coded map of depth or feed rates ")
            Me.PictureBox1.Location = New System.Drawing.Point(490, -58)
            Me.PictureBox1.Name = "PictureBox1"
            Me.HelpProvider1.SetShowHelp(Me.PictureBox1, True)
            Me.PictureBox1.Size = New System.Drawing.Size(382, 295)
            Me.PictureBox1.TabIndex = 14
            Me.PictureBox1.TabStop = False
            '
            'ContextMenu2
            '
            Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ctxdepthdisplay, Me.ctxtoolpath, Me.ctxdepthmap, Me.ctxfrmap, Me.ctxjumpnc})
            '
            'ctxdepthdisplay
            '
            Me.ctxdepthdisplay.Index = 0
            Me.ctxdepthdisplay.Text = "Set depth display location"
            '
            'ctxtoolpath
            '
            Me.ctxtoolpath.Index = 1
            Me.ctxtoolpath.Text = "Display toolpath"
            '
            'ctxdepthmap
            '
            Me.ctxdepthmap.Index = 2
            Me.ctxdepthmap.Text = "Depth Map"
            '
            'ctxfrmap
            '
            Me.ctxfrmap.Index = 3
            Me.ctxfrmap.Text = "Feedrate Map"
            '
            'ctxjumpnc
            '
            Me.ctxjumpnc.Index = 4
            Me.ctxjumpnc.Text = "Jump to NC Line "
            '
            'txtdepthatcursor
            '
            Me.txtdepthatcursor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtdepthatcursor.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtdepthatcursor, "Model depth at cursor locatin")
            Me.txtdepthatcursor.Location = New System.Drawing.Point(25, 95)
            Me.txtdepthatcursor.Name = "txtdepthatcursor"
            Me.txtdepthatcursor.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtdepthatcursor, True)
            Me.txtdepthatcursor.Size = New System.Drawing.Size(56, 20)
            Me.txtdepthatcursor.TabIndex = 15
            Me.txtdepthatcursor.Text = "0.000"
            '
            'Label7
            '
            Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(10, 97)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(12, 16)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "D"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtcursory
            '
            Me.txtcursory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursory.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtcursory, "Cursor Y coordinate")
            Me.txtcursory.Location = New System.Drawing.Point(25, 75)
            Me.txtcursory.Name = "txtcursory"
            Me.txtcursory.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursory, True)
            Me.txtcursory.Size = New System.Drawing.Size(56, 20)
            Me.txtcursory.TabIndex = 15
            Me.txtcursory.Text = "0.000"
            '
            'txtcursorx
            '
            Me.txtcursorx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursorx.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtcursorx, "Cursor X coordinate")
            Me.txtcursorx.Location = New System.Drawing.Point(25, 55)
            Me.txtcursorx.Name = "txtcursorx"
            Me.txtcursorx.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursorx, True)
            Me.txtcursorx.Size = New System.Drawing.Size(56, 20)
            Me.txtcursorx.TabIndex = 15
            Me.txtcursorx.Text = "0.000"
            '
            'Label9
            '
            Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = True
            Me.Label9.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label9.Location = New System.Drawing.Point(11, 157)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(11, 16)
            Me.Label9.TabIndex = 1
            Me.Label9.Text = "F"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Label10
            '
            Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(10, 57)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(12, 16)
            Me.Label10.TabIndex = 1
            Me.Label10.Text = "X"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'maxfeedrate
            '
            Me.maxfeedrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.maxfeedrate.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.maxfeedrate, "Max feed rate in NC program")
            Me.maxfeedrate.Location = New System.Drawing.Point(100, 60)
            Me.maxfeedrate.Name = "maxfeedrate"
            Me.maxfeedrate.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.maxfeedrate, True)
            Me.maxfeedrate.Size = New System.Drawing.Size(113, 20)
            Me.maxfeedrate.TabIndex = 1
            Me.maxfeedrate.Text = ""
            '
            'Label11
            '
            Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(21, 60)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(74, 16)
            Me.Label11.TabIndex = 1
            Me.Label11.Text = "Max Feedrate"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'maxdfeedrate
            '
            Me.maxdfeedrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.maxdfeedrate.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.maxdfeedrate, "Max change in feed rate between consecutive NC lines")
            Me.maxdfeedrate.Location = New System.Drawing.Point(100, 85)
            Me.maxdfeedrate.Multiline = True
            Me.maxdfeedrate.Name = "maxdfeedrate"
            Me.maxdfeedrate.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.maxdfeedrate, True)
            Me.maxdfeedrate.Size = New System.Drawing.Size(113, 32)
            Me.maxdfeedrate.TabIndex = 1
            Me.maxdfeedrate.Text = ""
            '
            'Label12
            '
            Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(30, 85)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(65, 16)
            Me.Label12.TabIndex = 1
            Me.Label12.Text = "Max Delta F"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.Label15)
            Me.GroupBox1.Controls.Add(Me.tooshal)
            Me.GroupBox1.Controls.Add(Me.pct_tooshallow)
            Me.GroupBox1.Controls.Add(Me.Label10)
            Me.GroupBox1.Controls.Add(Me.txtcursorx)
            Me.GroupBox1.Controls.Add(Me.Label13)
            Me.GroupBox1.Controls.Add(Me.txtcursory)
            Me.GroupBox1.Controls.Add(Me.Label9)
            Me.GroupBox1.Controls.Add(Me.txtcursorf)
            Me.GroupBox1.Controls.Add(Me.Label7)
            Me.GroupBox1.Controls.Add(Me.txtdepthatcursor)
            Me.GroupBox1.Controls.Add(Me.txtcursorn)
            Me.GroupBox1.Controls.Add(Me.Label14)
            Me.GroupBox1.Controls.Add(Me.Intolerance)
            Me.GroupBox1.Controls.Add(Me.pcttoodeep)
            Me.GroupBox1.Controls.Add(Me.pctthrupart)
            Me.GroupBox1.Controls.Add(Me.intoler)
            Me.GroupBox1.Controls.Add(Me.toodeep)
            Me.GroupBox1.Controls.Add(Me.thrupart)
            Me.GroupBox1.Controls.Add(Me.Label16)
            Me.GroupBox1.Controls.Add(Me.txtcursordnom)
            Me.GroupBox1.Controls.Add(Me.Label19)
            Me.GroupBox1.Controls.Add(Me.txtcursormi)
            Me.GroupBox1.Controls.Add(Me.Label21)
            Me.GroupBox1.Controls.Add(Me.txtDepthStarting)
            Me.GroupBox1.Controls.Add(Me.Label22)
            Me.GroupBox1.Controls.Add(Me.txtCursorMask)
            Me.GroupBox1.Controls.Add(Me.Label23)
            Me.HelpProvider1.SetHelpString(Me.GroupBox1, "Displays information about the surface at the cursor position ")
            Me.GroupBox1.Location = New System.Drawing.Point(468, 279)
            Me.GroupBox1.Name = "GroupBox1"
            Me.HelpProvider1.SetShowHelp(Me.GroupBox1, True)
            Me.GroupBox1.Size = New System.Drawing.Size(214, 207)
            Me.GroupBox1.TabIndex = 17
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Display Legend"
            '
            'Label15
            '
            Me.Label15.AutoSize = True
            Me.Label15.Location = New System.Drawing.Point(135, 25)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(42, 16)
            Me.Label15.TabIndex = 19
            Me.Label15.Text = "Legend"
            '
            'tooshal
            '
            Me.tooshal.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.tooshal.Location = New System.Drawing.Point(120, 45)
            Me.tooshal.Name = "tooshal"
            Me.tooshal.ReadOnly = True
            Me.tooshal.Size = New System.Drawing.Size(75, 20)
            Me.tooshal.TabIndex = 18
            Me.tooshal.Text = ""
            '
            'pct_tooshallow
            '
            Me.pct_tooshallow.BackColor = System.Drawing.Color.Blue
            Me.pct_tooshallow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pct_tooshallow.Location = New System.Drawing.Point(100, 47)
            Me.pct_tooshallow.Name = "pct_tooshallow"
            Me.pct_tooshallow.Size = New System.Drawing.Size(15, 15)
            Me.pct_tooshallow.TabIndex = 17
            Me.pct_tooshallow.TabStop = False
            '
            'Label13
            '
            Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label13.AutoSize = True
            Me.Label13.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label13.Location = New System.Drawing.Point(10, 77)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(12, 16)
            Me.Label13.TabIndex = 1
            Me.Label13.Text = "Y"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtcursorf
            '
            Me.txtcursorf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursorf.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtcursorf, "Feed rate at cursor location")
            Me.txtcursorf.Location = New System.Drawing.Point(25, 155)
            Me.txtcursorf.Name = "txtcursorf"
            Me.txtcursorf.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursorf, True)
            Me.txtcursorf.Size = New System.Drawing.Size(56, 20)
            Me.txtcursorf.TabIndex = 15
            Me.txtcursorf.Text = "0"
            '
            'txtcursorn
            '
            Me.txtcursorn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursorn.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtcursorn, "Line number at cursor locaton")
            Me.txtcursorn.Location = New System.Drawing.Point(25, 35)
            Me.txtcursorn.Name = "txtcursorn"
            Me.txtcursorn.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursorn, True)
            Me.txtcursorn.Size = New System.Drawing.Size(56, 20)
            Me.txtcursorn.TabIndex = 15
            Me.txtcursorn.Text = ""
            '
            'Label14
            '
            Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label14.AutoSize = True
            Me.Label14.Location = New System.Drawing.Point(10, 37)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(12, 16)
            Me.Label14.TabIndex = 1
            Me.Label14.Text = "N"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Intolerance
            '
            Me.Intolerance.BackColor = System.Drawing.Color.Lime
            Me.Intolerance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Intolerance.Location = New System.Drawing.Point(100, 67)
            Me.Intolerance.Name = "Intolerance"
            Me.Intolerance.Size = New System.Drawing.Size(15, 15)
            Me.Intolerance.TabIndex = 17
            Me.Intolerance.TabStop = False
            '
            'pcttoodeep
            '
            Me.pcttoodeep.BackColor = System.Drawing.Color.Yellow
            Me.pcttoodeep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pcttoodeep.Location = New System.Drawing.Point(100, 87)
            Me.pcttoodeep.Name = "pcttoodeep"
            Me.pcttoodeep.Size = New System.Drawing.Size(15, 15)
            Me.pcttoodeep.TabIndex = 17
            Me.pcttoodeep.TabStop = False
            '
            'pctthrupart
            '
            Me.pctthrupart.BackColor = System.Drawing.Color.Red
            Me.pctthrupart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pctthrupart.Location = New System.Drawing.Point(100, 107)
            Me.pctthrupart.Name = "pctthrupart"
            Me.pctthrupart.Size = New System.Drawing.Size(15, 15)
            Me.pctthrupart.TabIndex = 17
            Me.pctthrupart.TabStop = False
            '
            'intoler
            '
            Me.intoler.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.intoler.Location = New System.Drawing.Point(120, 65)
            Me.intoler.Name = "intoler"
            Me.intoler.ReadOnly = True
            Me.intoler.Size = New System.Drawing.Size(75, 20)
            Me.intoler.TabIndex = 18
            Me.intoler.Text = ""
            '
            'toodeep
            '
            Me.toodeep.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.toodeep.Location = New System.Drawing.Point(120, 85)
            Me.toodeep.Name = "toodeep"
            Me.toodeep.ReadOnly = True
            Me.toodeep.Size = New System.Drawing.Size(75, 20)
            Me.toodeep.TabIndex = 18
            Me.toodeep.Text = ""
            '
            'thrupart
            '
            Me.thrupart.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.thrupart.Location = New System.Drawing.Point(120, 105)
            Me.thrupart.Name = "thrupart"
            Me.thrupart.ReadOnly = True
            Me.thrupart.Size = New System.Drawing.Size(75, 20)
            Me.thrupart.TabIndex = 18
            Me.thrupart.Text = ""
            '
            'Label16
            '
            Me.Label16.AutoSize = True
            Me.Label16.Location = New System.Drawing.Point(30, 15)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(38, 16)
            Me.Label16.TabIndex = 19
            Me.Label16.Text = "Cursor"
            '
            'txtcursordnom
            '
            Me.txtcursordnom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursordnom.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtcursordnom, "Target depth at cursor location")
            Me.txtcursordnom.Location = New System.Drawing.Point(25, 115)
            Me.txtcursordnom.Name = "txtcursordnom"
            Me.txtcursordnom.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursordnom, True)
            Me.txtcursordnom.Size = New System.Drawing.Size(56, 20)
            Me.txtcursordnom.TabIndex = 15
            Me.txtcursordnom.Text = "0.000"
            '
            'Label19
            '
            Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label19.AutoSize = True
            Me.Label19.Location = New System.Drawing.Point(7, 117)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(15, 16)
            Me.Label19.TabIndex = 16
            Me.Label19.Text = "Dt"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtcursormi
            '
            Me.txtcursormi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtcursormi.BackColor = System.Drawing.SystemColors.Control
            Me.HelpProvider1.SetHelpString(Me.txtcursormi, "Machinability Index at cursor location")
            Me.txtcursormi.Location = New System.Drawing.Point(130, 155)
            Me.txtcursormi.Name = "txtcursormi"
            Me.txtcursormi.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtcursormi, True)
            Me.txtcursormi.Size = New System.Drawing.Size(56, 20)
            Me.txtcursormi.TabIndex = 15
            Me.txtcursormi.Text = "0"
            '
            'Label21
            '
            Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label21.AutoSize = True
            Me.Label21.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label21.Location = New System.Drawing.Point(105, 155)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(17, 16)
            Me.Label21.TabIndex = 1
            Me.Label21.Text = "MI"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtDepthStarting
            '
            Me.txtDepthStarting.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtDepthStarting.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txtDepthStarting, "Starting Depth at cursor location")
            Me.txtDepthStarting.Location = New System.Drawing.Point(25, 135)
            Me.txtDepthStarting.Name = "txtDepthStarting"
            Me.txtDepthStarting.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtDepthStarting, True)
            Me.txtDepthStarting.Size = New System.Drawing.Size(56, 20)
            Me.txtDepthStarting.TabIndex = 15
            Me.txtDepthStarting.Text = "0.000"
            '
            'Label22
            '
            Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label22.AutoSize = True
            Me.Label22.Location = New System.Drawing.Point(4, 137)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(18, 16)
            Me.Label22.TabIndex = 16
            Me.Label22.Text = "Ds"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtCursorMask
            '
            Me.txtCursorMask.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtCursorMask.BackColor = System.Drawing.SystemColors.Control
            Me.HelpProvider1.SetHelpString(Me.txtCursorMask, "Machinability Index at cursor location")
            Me.txtCursorMask.Location = New System.Drawing.Point(130, 135)
            Me.txtCursorMask.Name = "txtCursorMask"
            Me.txtCursorMask.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txtCursorMask, True)
            Me.txtCursorMask.Size = New System.Drawing.Size(56, 20)
            Me.txtCursorMask.TabIndex = 15
            Me.txtCursorMask.Text = "0"
            '
            'Label23
            '
            Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label23.AutoSize = True
            Me.Label23.ImageAlign = System.Drawing.ContentAlignment.BottomRight
            Me.Label23.Location = New System.Drawing.Point(95, 135)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(31, 16)
            Me.Label23.TabIndex = 1
            Me.Label23.Text = "Mask"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'PictureBox2
            '
            Me.PictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.PictureBox2.ContextMenu = Me.ContextMenu3
            Me.HelpProvider1.SetHelpString(Me.PictureBox2, "Displays cross section created with scissor tooll")
            Me.PictureBox2.Location = New System.Drawing.Point(700, 445)
            Me.PictureBox2.Name = "PictureBox2"
            Me.HelpProvider1.SetShowHelp(Me.PictureBox2, True)
            Me.PictureBox2.Size = New System.Drawing.Size(225, 175)
            Me.PictureBox2.TabIndex = 21
            Me.PictureBox2.TabStop = False
            Me.ToolTip1.SetToolTip(Me.PictureBox2, "Cross-section View")
            '
            'ContextMenu3
            '
            Me.ContextMenu3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ctx1scale, Me.ctxstretchscale})
            '
            'ctx1scale
            '
            Me.ctx1scale.Index = 0
            Me.ctx1scale.Text = "1:1 Scale"
            '
            'ctxstretchscale
            '
            Me.ctxstretchscale.Index = 1
            Me.ctxstretchscale.Text = "Stretch Y to Fit"
            '
            'txt_timetomachine
            '
            Me.txt_timetomachine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txt_timetomachine.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.txt_timetomachine, "Time to machine number of runs specified")
            Me.txt_timetomachine.Location = New System.Drawing.Point(100, 10)
            Me.txt_timetomachine.Name = "txt_timetomachine"
            Me.txt_timetomachine.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.txt_timetomachine, True)
            Me.txt_timetomachine.Size = New System.Drawing.Size(113, 20)
            Me.txt_timetomachine.TabIndex = 1
            Me.txt_timetomachine.Text = ""
            '
            'zoom
            '
            Me.zoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.zoom.Image = CType(resources.GetObject("zoom.Image"), System.Drawing.Image)
            Me.zoom.Location = New System.Drawing.Point(5, 5)
            Me.zoom.Name = "zoom"
            Me.zoom.Size = New System.Drawing.Size(30, 30)
            Me.zoom.TabIndex = 19
            Me.ToolTip1.SetToolTip(Me.zoom, "Zoom Window")
            '
            'zoomext
            '
            Me.zoomext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.zoomext.Image = CType(resources.GetObject("zoomext.Image"), System.Drawing.Image)
            Me.zoomext.Location = New System.Drawing.Point(40, 5)
            Me.zoomext.Name = "zoomext"
            Me.zoomext.Size = New System.Drawing.Size(30, 30)
            Me.zoomext.TabIndex = 19
            Me.ToolTip1.SetToolTip(Me.zoomext, "Zoom Extents")
            '
            'pan
            '
            Me.pan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.pan.Image = CType(resources.GetObject("pan.Image"), System.Drawing.Image)
            Me.pan.Location = New System.Drawing.Point(75, 5)
            Me.pan.Name = "pan"
            Me.pan.Size = New System.Drawing.Size(30, 30)
            Me.pan.TabIndex = 19
            Me.ToolTip1.SetToolTip(Me.pan, "Pan")
            '
            'crossh
            '
            Me.crossh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.crossh.Image = CType(resources.GetObject("crossh.Image"), System.Drawing.Image)
            Me.crossh.Location = New System.Drawing.Point(110, 5)
            Me.crossh.Name = "crossh"
            Me.crossh.Size = New System.Drawing.Size(30, 30)
            Me.crossh.TabIndex = 19
            Me.ToolTip1.SetToolTip(Me.crossh, "Measure")
            '
            'xsection
            '
            Me.xsection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.xsection.Image = CType(resources.GetObject("xsection.Image"), System.Drawing.Image)
            Me.xsection.Location = New System.Drawing.Point(145, 5)
            Me.xsection.Name = "xsection"
            Me.xsection.Size = New System.Drawing.Size(30, 30)
            Me.xsection.TabIndex = 19
            Me.ToolTip1.SetToolTip(Me.xsection, "Cross-Section")
            '
            'PrintDocument2
            '
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.zoom)
            Me.Panel1.Controls.Add(Me.pan)
            Me.Panel1.Controls.Add(Me.zoomext)
            Me.Panel1.Controls.Add(Me.crossh)
            Me.Panel1.Controls.Add(Me.xsection)
            Me.Panel1.Location = New System.Drawing.Point(715, 395)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(185, 45)
            Me.Panel1.TabIndex = 20
            '
            'txtxsectdepth
            '
            Me.txtxsectdepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtxsectdepth.Location = New System.Drawing.Point(145, 0)
            Me.txtxsectdepth.Name = "txtxsectdepth"
            Me.txtxsectdepth.Size = New System.Drawing.Size(70, 20)
            Me.txtxsectdepth.TabIndex = 22
            Me.txtxsectdepth.Text = ""
            Me.txtxsectdepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label17.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.Label17.Location = New System.Drawing.Point(130, 0)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(15, 20)
            Me.Label17.TabIndex = 23
            Me.Label17.Text = "D"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.Label17)
            Me.Panel2.Controls.Add(Me.txtxsectdepth)
            Me.Panel2.Controls.Add(Me.Label20)
            Me.Panel2.Controls.Add(Me.txtxsectpos)
            Me.Panel2.Location = New System.Drawing.Point(705, 450)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(220, 25)
            Me.Panel2.TabIndex = 24
            '
            'Label20
            '
            Me.Label20.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label20.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.Label20.Location = New System.Drawing.Point(0, 0)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(15, 20)
            Me.Label20.TabIndex = 23
            Me.Label20.Text = "X"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtxsectpos
            '
            Me.txtxsectpos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtxsectpos.Location = New System.Drawing.Point(15, 0)
            Me.txtxsectpos.Name = "txtxsectpos"
            Me.txtxsectpos.Size = New System.Drawing.Size(70, 20)
            Me.txtxsectpos.TabIndex = 22
            Me.txtxsectpos.Text = ""
            Me.txtxsectpos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'Label18
            '
            Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Label18.AutoSize = True
            Me.Label18.Location = New System.Drawing.Point(5, 10)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(88, 16)
            Me.Label18.TabIndex = 1
            Me.Label18.Text = "Time to machine"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.txt_timetomachine)
            Me.Panel3.Controls.Add(Me.Label12)
            Me.Panel3.Controls.Add(Me.maxfeedrate)
            Me.Panel3.Controls.Add(Me.maxdfeedrate)
            Me.Panel3.Controls.Add(Me.Label18)
            Me.Panel3.Controls.Add(Me.Label11)
            Me.Panel3.Controls.Add(Me.minFeedrate)
            Me.Panel3.Controls.Add(Me.Label24)
            Me.Panel3.Location = New System.Drawing.Point(230, 300)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(220, 125)
            Me.Panel3.TabIndex = 25
            '
            'sbfrm1
            '
            Me.sbfrm1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.sbfrm1.Dock = System.Windows.Forms.DockStyle.None
            Me.sbfrm1.Location = New System.Drawing.Point(5, 581)
            Me.sbfrm1.Name = "sbfrm1"
            Me.sbfrm1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpstarttime, Me.sbpstatus, Me.startdepth, Me.targetdepth, Me.parmfilename, Me.mask, Me.MI})
            Me.sbfrm1.ShowPanels = True
            Me.sbfrm1.Size = New System.Drawing.Size(823, 20)
            Me.sbfrm1.SizingGrip = False
            Me.sbfrm1.TabIndex = 26
            Me.sbfrm1.Text = "Status"
            '
            'sbpstarttime
            '
            Me.sbpstarttime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
            Me.sbpstarttime.Width = 10
            '
            'sbpstatus
            '
            Me.sbpstatus.Width = 180
            '
            'startdepth
            '
            Me.startdepth.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.startdepth.Width = 126
            '
            'targetdepth
            '
            Me.targetdepth.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.targetdepth.Width = 126
            '
            'parmfilename
            '
            Me.parmfilename.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.parmfilename.Width = 126
            '
            'mask
            '
            Me.mask.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.mask.Width = 126
            '
            'MI
            '
            Me.MI.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.MI.Width = 126
            '
            'Timer1
            '
            Me.Timer1.Enabled = True
            '
            'newMiOption
            '
            Me.HelpProvider1.SetHelpString(Me.newMiOption, "Adjust feed rates in file based on model depth")
            Me.newMiOption.Location = New System.Drawing.Point(16, 120)
            Me.newMiOption.Name = "newMiOption"
            Me.HelpProvider1.SetShowHelp(Me.newMiOption, True)
            Me.newMiOption.TabIndex = 0
            Me.newMiOption.Text = "New MI surface"
            '
            'minFeedrate
            '
            Me.minFeedrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.minFeedrate.BackColor = System.Drawing.SystemColors.ControlLightLight
            Me.HelpProvider1.SetHelpString(Me.minFeedrate, "Max feed rate in NC program")
            Me.minFeedrate.Location = New System.Drawing.Point(100, 35)
            Me.minFeedrate.Name = "minFeedrate"
            Me.minFeedrate.ReadOnly = True
            Me.HelpProvider1.SetShowHelp(Me.minFeedrate, True)
            Me.minFeedrate.Size = New System.Drawing.Size(113, 20)
            Me.minFeedrate.TabIndex = 1
            Me.minFeedrate.Text = ""
            '
            'Label24
            '
            Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label24.AutoSize = True
            Me.Label24.Location = New System.Drawing.Point(20, 35)
            Me.Label24.Name = "Label24"
            Me.Label24.Size = New System.Drawing.Size(71, 16)
            Me.Label24.TabIndex = 1
            Me.Label24.Text = "Min Feedrate"
            Me.Label24.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(920, 611)
            Me.Controls.Add(Me.sbfrm1)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.ProgressBar1)
            Me.Controls.Add(Me.Richtextbox1)
            Me.Controls.Add(Me.Runmodel)
            Me.Controls.Add(Me.stopmodel)
            Me.Controls.Add(Me.outputoptions)
            Me.Controls.Add(Me.runinfo)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.PictureBox2)
            Me.Controls.Add(Me.Panel3)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Menu = Me.mainMenu1
            Me.Name = "Form1"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
            Me.Text = "ABMACH Simulator"
            Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))
            Me.runinfo.ResumeLayout(False)
            Me.outputoptions.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            CType(Me.sbpstarttime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.sbpstatus, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startdepth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.targetdepth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.parmfilename, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mask, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MI, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub 'InitializeComponent

        Protected Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

            setcomponentlocations()

            If Me.WindowState <> FormWindowState.Minimized Then
                If Me.model_run_success Then
                    'Me.DisplayScrollBars()
                    ' Me.SetScrollBarValues()

                    Me.calczoomexts()
                    Me.refreshpicture(zoomextents)
                End If
            End If
            Me.Refresh()


        End Sub 'Form1_Resize

        Sub setcomponentlocations()
            'set size and location of controls when main form is loaded or resized
            'Me.Richtextbox1.SetBounds(5, 20, CInt(Me.ClientRectangle.Width * 0.5), CInt(Me.ClientRectangle.Height * 0.45))
            Dim textWindowWidth As Integer = Math.Min(CInt(Me.ClientRectangle.Width * 0.5), 480)
            Me.Richtextbox1.SetBounds(5, 20, textWindowWidth, CInt(Me.ClientRectangle.Height * 0.45))
            'Me.PictureBox1.SetBounds(Me.Richtextbox1.Width + 10, 20, CInt(Me.ClientRectangle.Width * 0.5) - 35, CInt(Me.ClientRectangle.Height * 0.45))
            Me.PictureBox1.SetBounds(Me.Richtextbox1.Width + 10, 20, Me.ClientRectangle.Width - Me.Richtextbox1.Width - 20, CInt(Me.ClientRectangle.Height * 0.45))
            Me.GroupBox1.SetBounds(Me.PictureBox1.Location.X, Me.PictureBox1.Location.Y + Me.PictureBox1.Height + 15, 215, 180)
            Me.Panel1.SetBounds(Me.GroupBox1.Location.X + Me.GroupBox1.Width + 5, Me.GroupBox1.Location.Y, 185, 45)
            Me.PictureBox2.SetBounds(Me.Panel1.Location.X, Me.Panel1.Location.Y + Me.Panel1.Height + 5, Me.ClientRectangle.Width - Me.Panel1.Location.X - 20, Me.ClientRectangle.Height - (Me.Panel1.Location.Y + Me.Panel1.Height) - 35)

            Me.Panel2.SetBounds(Me.PictureBox2.Left, Me.PictureBox2.Top, Me.PictureBox2.Width, 20)

            Me.sbfrm1.SetBounds(0, Me.ClientRectangle.Height - 30, Me.ClientRectangle.Width - 25, 25)
            'set zoom factor to 1 and offset to 0 when main form is loaded or resized
            screendisplay.X = 0
            screendisplay.Y = 0
            screendisplay.xscalefactor = 1
            screendisplay.yscalefactor = 1
            screendisplay.Width = PictureBox1.Width
            screendisplay.Height = PictureBox1.Height

            nozoom.xscalefactor = 1
            nozoom.yscalefactor = 1
            nozoom.X = 0
            nozoom.Y = 0
            nozoom.Width = PictureBox1.Width
            nozoom.Height = PictureBox1.Height
        End Sub 'setcomponentlocations

        Public Overloads Shared Sub Main(ByVal args() As String)

            Application.Run(New Form1)

        End Sub 'Main 
#End Region
#Region " Main Form Menu code "
        Protected Sub mnuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
            Dim abt As about = New about
            abt.ShowDialog()
        End Sub 'mnuAbout_Click
        Protected Sub mnuSelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSelectAll.Click
            Richtextbox1.SelectAll()
        End Sub 'mnuSelectAll_Click
        Protected Sub mnuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrint.Click
            If Me.fileloaded Then
                printDialog1.Document = ThePrintDocument
                Dim strText As String = Me.Richtextbox1.Text
                myReader = New StringReader(strText)
                If printDialog1.ShowDialog() = DialogResult.OK Then
                    Me.ThePrintDocument.Print()
                End If
            End If

        End Sub 'mnuPrint_Click
        Private Sub mnuprintpic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuprintpic.Click
            If Me.model_run_success Then
                printDialog1.Document = PrintDocument2
                'Dim strText As String = Me.Richtextbox1.Text
                'myReader = New StringReader(strText)
                If printDialog1.ShowDialog() = DialogResult.OK Then
                    Me.PrintDocument2.Print()

                End If
            End If
        End Sub 'mnuprintpic_Click
        Protected Sub mnuPageSetUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPageSetUp.Click
            Dim docPrn As New PrintDocument
            docPrn.DocumentName = Richtextbox1.Text
            pageSetupDialog1.Document = docPrn
            pageSetupDialog1.ShowDialog()
        End Sub 'mnuPageSetUp_Click
        Protected Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
            'check for unsaved data

            Dim filesaved As Boolean = checkUnSavedData()
            If filesaved Then Me.Close()

        End Sub 'mnuExit_Click
        Protected Sub mnuSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSave.Click
            SaveFile()
            Me.Text = "ABMACH Simulator-" & ncfilename
        End Sub 'mnuSave_Click
        Protected Sub mnuSaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSaveAs.Click
            'Save File
            SaveFile()
            Me.Text = "ABMACH Simulator-" & ncfilename
        End Sub 'mnuSaveAs_Click
        Private Function SaveFile() As Boolean
            Dim i As Integer
            Try
                If Me.Richtextbox1.Text <> "" Then
                    Dim savefiledialog1 As New SaveFileDialog
                    savefiledialog1.Filter = "All Files(*.*)|*.*"
                    savefiledialog1.DefaultExt = ".nc"
                    savefiledialog1.AddExtension = True
                    savefiledialog1.FileName = ncfilename

                    ' get the file name to save the list view information in from the standard save dialog
                    If savefiledialog1.ShowDialog() = DialogResult.OK Then
                        ' open a stream for writing and create a StreamWriter to use to implement the stream
                        Dim fs As New FileStream(savefiledialog1.FileName, FileMode.Create, FileAccess.Write)
                        Dim m_streamWriter As New StreamWriter(fs)
                        ncfilename = savefiledialog1.FileName
                        ReDim nclines(Richtextbox1.Lines.GetUpperBound(0))
                        nclines = Richtextbox1.Lines

                        For i = 0 To Richtextbox1.Lines.GetUpperBound(0)
                            m_streamWriter.WriteLine(nclines(i))
                        Next


                        'm_streamWriter.Flush()
                        m_streamWriter.Close()
                    End If
                    ' savefiledialog1.Dispose()
                End If
                blnSaveChkFlag = False
            Catch em As Exception
                MessageBox.Show(em.Message.ToString)
            End Try


        End Function 'SaveFile
        Protected Sub ThePrintDocument_PrintPage(ByVal sender As Object, ByVal ev As System.Drawing.Printing.PrintPageEventArgs) Handles ThePrintDocument.PrintPage
            Try
                Dim linesPerPage As Single = 0
                Dim yPosition As Single = 0
                Dim count As Integer = 0
                Dim leftMargin As Single = ev.MarginBounds.Left
                Dim topMargin As Single = ev.MarginBounds.Top
                Dim line As String = Nothing
                Dim printFont As Font = Me.Richtextbox1.Font
                Dim myBrush As New SolidBrush(Color.Black)

                ' Work out the number of lines per page, using the MarginBounds.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

                ' Iterate over the string using the StringReader, printing each line.
                line = myReader.ReadLine()
                While count < linesPerPage And (Nothing <> line)

                    ' calculate the next line position based on 
                    ' the height of the font according to the printing device
                    yPosition = (topMargin + (count * printFont.GetHeight(ev.Graphics)))

                    ' draw the next line in the rich edit control
                    ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, New StringFormat)
                    count += 1
                    line = myReader.ReadLine()
                End While

                ' If there are more lines, print another page.
                If Not (line Is Nothing) Then
                    ev.HasMorePages = True
                Else
                    ev.HasMorePages = False
                End If
                myBrush.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "thePrintDocument_PrintPage")
            End Try
        End Sub 'ThePrintDocument_PrintPage

        Private Sub PrintDocument2_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage
            Try
                Dim gp As Graphics = e.Graphics

                pagedisplay.Width = e.MarginBounds.Width
                pagedisplay.Height = e.MarginBounds.Height
                pagedisplay.X = e.MarginBounds.Left
                pagedisplay.Y = e.MarginBounds.Bottom
                'zoomwindow.xscalefactor = Math.Min(PictureBox1.Width / (1.3 * size_xarray), PictureBox1.Height / (1.3 * size_yarray))
                ' zoomwindow.xscalefactor = zoomextents.xscalefactor
                ' zoomwindow.yscalefactor = zoomextents.yscalefactor
                'zoomwindow.X = CInt((e.MarginBounds.Width / 2) - (zoomextents.xscalefactor * size_xarray / 2))
                'zoomwindow.Y = CInt((e.MarginBounds.Height / 2) - (zoomextents.yscalefactor * size_yarray / 2))
                zoomwindow.Height = size_yarray
                zoomwindow.Width = size_xarray
                zoomwindow.X = 0
                zoomwindow.Y = 0
                Me.calcpicturescalef(pagedisplay, zoomwindow, fittopage)
                If printDialog1.PrinterSettings.SupportsColor Then
                    Me.displaypicture(gp, fittopage, blueBrush, greenBrush, yellowBrush, redBrush, blackbrush)
                    If toolpathshown Then displaytoolpath(gp, fittopage, blackpen)
                Else
                    Me.displaypicture(gp, fittopage, g1brsh, g2brsh, g3brsh, g4brsh, blackbrush)
                    If toolpathshown Then displaytoolpath(gp, fittopage, blackpen)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "PrintDocument2_PrintPage")
            End Try


        End Sub 'PrintDocument2_PrintPage
        Protected Sub mnuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOpen.Click
            Try
                Dim openfiledialog1 As New OpenFileDialog
                Dim a As Integer = 0
                openfiledialog1.Filter = "NC files(*.nc)|*.nc|DAT files(*.dat)|*.dat|All Files(*.*)|*.*"
                openfiledialog1.FilterIndex = 1




                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    toolpathshown = False
                    Runmodel.Enabled = False
                    stopmodel.Enabled = False
                    clearpicturebox1()
                    clearpicturebox2()
                    refreshpanel(1, "Reading File")
                    Me.pan.Enabled = False
                    Me.zoom.Enabled = False
                    Me.zoomext.Enabled = False
                    Me.crossh.Enabled = False

                    Me.crossactive = True
                    Me.zoomactive = False
                    Me.panactive = False
                    Me.xsectactive = False

                    Me.crossh.BackColor = SystemColors.ActiveCaption
                    Me.PictureBox1.Enabled = False
                    Me.xsection.Enabled = False
                    Me.PictureBox2.Enabled = False
                    invalidateSurfaces()

                    Dim fs As New FileStream(openfiledialog1.FileName, FileMode.Open, FileAccess.Read)
                    ncfilename = openfiledialog1.FileName
                    Dim m_streamReader As New StreamReader(fs)
                    ' Read to the file using StreamReader  class
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)

                    Me.Text = "ABMACH Simulator-" & ncfilename


                    ' Read  each line of the stream and parse until last line is reached
                    Me.Richtextbox1.Text = ""

                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                    Dim strLine As String = m_streamReader.ReadLine()
                    While Not (strLine Is Nothing)
                        strLine = m_streamReader.ReadLine()
                        a += 1
                    End While
                    ReDim nclines(a)
                    a = 0
                    ' Read  each line of the stream 
                    m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
                    strLine = m_streamReader.ReadLine()
                    While Not (strLine Is Nothing)
                        ' Me.Richtextbox1.Text += strLine + ControlChars.CrLf
                        nclines(a) = strLine
                        strLine = m_streamReader.ReadLine()
                        a += 1
                    End While

                    ' Close the stream
                    m_streamReader.Close()

                    'Me.Richtextbox1.Lines = nclines
                    rewritetextbox(nclines)
                    Me.Richtextbox1.Refresh()

                    scanfile()

                End If

                'openfiledialog1.Dispose()

            Catch em As Exception
                MessageBox.Show(em.Message.ToString() & "sub:openfile")
            End Try



        End Sub 'mnuOpen_Click
        Protected Sub mnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDelete.Click
            delete()
        End Sub 'mnuDelete_Click
        Protected Sub mnuCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCut.Click
            cut()
        End Sub 'mnuCut_Click
        Private Sub cut()
            Richtextbox1.Cut()
        End Sub
        Private Sub delete()

            If Richtextbox1.SelectedText <> "" Then
                Richtextbox1.SelectedText = ""
            Else
                Richtextbox1.Select(Richtextbox1.SelectionStart, 1)
                Richtextbox1.SelectedText = ""
            End If
        End Sub
        Protected Sub mnuUndo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuUndo.Click
            Richtextbox1.Undo()
        End Sub 'mnuUndo_Click
        Protected Sub mnuCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCopy.Click
            copy()
        End Sub 'mnuCopy_Click
        Private Sub paste()
            'Using Clipboard complex....U can use Paste method-One line statement
            ' textBox1.Paste();
            '******Using ClipBoard***************
            'Declare an IDataObject to hold the data returned from the clipboard.
            'Then retrieve the data from the clipboard.
            Dim iData As IDataObject = Clipboard.GetDataObject()
            'Determine whether the data is in a format you can use.
            If iData.GetDataPresent(DataFormats.Text) Then
                'Yes it is, so display it in a text box.			
                Richtextbox1.SelectedText = CType(iData.GetData(DataFormats.Text), [String])
            End If
        End Sub
        Protected Sub mnuPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
            paste()
        End Sub 'mnuPaste_Click
        Private Sub copy()
            Clipboard.SetDataObject(Richtextbox1.SelectedText, True)

        End Sub
        Protected Sub mnuNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNew.Click

            'check for unsaved data
            If checkUnSavedData() Then
                Richtextbox1.Clear()
                blnSaveChkFlag = False
                Me.Text = "ABMACHSim"
            End If
        End Sub 'mnuNew_Click
        Private Sub mnutest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnutest.Click
            Dim parmtst As New parminput
            With parminfo
                .testdepth.Visible = True
                .testpasses.Visible = True
                .testspeed.Visible = True
                .Label11.Visible = True
                .Label12.Visible = True
                .Label13.Visible = True
                parmpreload()
                .Height = 570
                .ShowDialog()

            End With

            If parminfo.DialogResult = DialogResult.OK Then

                Me.runnumber.Text = CStr(numberruns)
                Me.curmrr.Text = CStr(depth_per_run)
                Me.Refresh()
            End If

        End Sub 'mnutest_click
        Private Sub mnuman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuman.Click
            Dim parmin As New parminput
            With parminfo
                .testdepth.Visible = False
                .testpasses.Visible = False
                .testspeed.Visible = False
                .Label11.Visible = False
                .Label12.Visible = False
                .Label13.Visible = False
                .Groovedir.SelectedIndex = 1
                parmpreload()
                .Height = 478
                .number_of_runs.Focus()
                .ShowDialog()
                .BringToFront()
            End With
            If parminfo.DialogResult = DialogResult.OK Then

                Me.runnumber.Text = CStr(numberruns)
                Me.curmrr.Text = CStr(depth_per_run)
                Me.Refresh()
            End If
        End Sub 'mnuman_Click

        Private Sub mnuinfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuinfo.Click
            Dim stfiledir As String = Directory.GetCurrentDirectory
            Me.load_info_file(stfiledir)

        End Sub 'info_click
        Private Sub mnurescalefeedrates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurescalefeedrates.Click

            If fileloaded Then
                Dim newfeed(ilength) As Double
                Dim scalingfactor As Object
                Dim dbscalingfactor As Double
                Dim i As Integer
                Dim datavalid As Boolean

                Try

                    scalingfactor = InputBox("Enter Scaling Factor", "Rescale Feedrates", "1.0")

                    If IsNumeric(scalingfactor) Then
                        dbscalingfactor = CDbl(scalingfactor)
                        If dbscalingfactor > 0 Then
                            datavalid = True
                        Else
                            Throw New Exception("Invalid Scale Factor")
                        End If
                    End If

                    If datavalid = True Then
                        read_nc(nclines, istartrow, ifirstrow, ilastrow, dynjeton, vscaling)
                        rewritetextbox(nclines)
                        For i = 0 To ilength
                            newfeed(i) = nc(i).f * dbscalingfactor
                        Next
                        Me.replacefeedrates(newfeed)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            End If
        End Sub 'rescale feed rates
        Private Sub rewritetextbox(ByVal newtext() As String)
            Me.Richtextbox1.Lines = newtext
            Me.Richtextbox1.Refresh()
        End Sub
        Private Sub mnureplacefeedrates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnureplacefeedrates.Click
            If fileloaded Then
                Dim newfeed(ilength), dbfreplace As Double
                Dim freplace As Object

                Dim i As Integer
                Dim datavalid As Boolean

                Try
                    freplace = InputBox("Enter New Feedrate", "Replace Feedrates", CStr(Math.Round(startingFeedRate, 2)))
                    If IsNumeric(freplace) Then
                        dbfreplace = CDbl(freplace)
                        If dbfreplace > 0 Then
                            datavalid = True
                        Else
                            Throw New Exception("Invalid Feedrate")
                        End If
                    End If

                    If datavalid = True Then
                        nclines = Me.Richtextbox1.Lines
                        read_nc(nclines, istartrow, ifirstrow, ilastrow, dynjeton, vscaling)
                        Me.rewritetextbox(nclines)
                        For i = 0 To ilength
                            newfeed(i) = dbfreplace
                        Next
                        Me.replacefeedrates(newfeed)
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                End Try
            End If

        End Sub 'replace feedrates

        Private Sub mnudynjetonoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudynjetonoff.Click
            Dim i, j, ncl As Integer
            Dim jeton1dist, jeton2dist, jetoffdist As Double
            Dim dyn, dxn, dy1, dx1, xyd0, xyd1, xyd2, xyd3, xyd4, fd0, fd3, fd2, fd1 As Double
            Dim xd1, yd1, s1, ncp1x, ncp1y As Double
            Dim ncline, newnclines(), newncline As String
            nclines = Richtextbox1.Lines
            Dim ncLength As Integer = nclines.GetUpperBound(0)
            ReDim newnclines(3 * (nclines.GetUpperBound(0) + 5))
            j = 0
            read_nc(nclines, istartrow, ifirstrow, ilastrow, dynjeton, vscaling)
            Me.rewritetextbox(nclines)
            ncl = nc.GetUpperBound(0)
            If dynjeton = True Then
                MessageBox.Show("Dynamic Jet on/off already set")
            Else
                ilength += 2

                ReDim Preserve nc(ilength)

                'write lines to newnclines array as-is until jeton command is reached
                For i = 0 To nc(0).l - 1
                    ncline = nclines(i)
                    If ncline.StartsWith(machine.machinetag) Then
                        ncline = machine.dyntag
                        nclines(i) = ncline
                    End If
                    newnclines(i) = nclines(i)
                Next
                j = nc(0).l
                newnclines(j) = nclines(nc(0).l)
                j += 1
                newnclines(j) = "G28"
                j += 1
                If vscaling Then
                    newnclines(j) = nclines(nc(1).l - 1)
                    j += 1
                End If
                newnclines(j) = nclines(nc(1).l) 'first movement line
                j += 1
                'add dynamic jeton command
                newnclines(j) = machine.abrasiveOnMcode
                j += 1
                newnclines(j) = nclines(nc(2).l) '2nd movement line
                j += 1
                newnclines(j) = machine.jetOnMcode
                j += 1
                'loop through at start
                If vscaling Then
                    For i = nc(3).l - 1 To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                Else
                    For i = nc(3).l To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                End If
                'add start string 
                newnclines(j) = machine.startstring
                j += 1
                'add repeat start command
                newnclines(j) = machine.repeatstart
                j += 1
                'loop through inside repeat
                If vscaling Then
                    For i = nc(3).l - 1 To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                Else
                    For i = nc(3).l To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                End If
                newnclines(j) = machine.repeatstop 'insert loop ending command
                j += 1

                newnclines(j) = machine.endstring ' insert end string
                j += 1
                'loop through at finish
                If vscaling Then
                    For i = nc(3).l - 1 To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                Else
                    For i = nc(3).l To nc(ncl).l ' changed from ncl-3 5/7/2007
                        newnclines(j) = nclines(i)
                        j += 1
                    Next
                End If
                newnclines(j) = machine.abrasiveOffMcode
                j += 1
                If vscaling Then
                    newnclines(j) = nclines(nc(2).l - 1)
                    j += 1
                End If
                newnclines(j) = nclines(nc(2).l)
                j += 1

                newnclines(j) = machine.jetOffMcode
                j += 1

                If vscaling Then
                    j += 1
                    newnclines(j) = nclines(nc(4).l - 1)
                End If
                newnclines(j) = nclines(nc(4).l)
                j += 1
                newnclines(j) = "G29"
                j += 1
                For i = ncLength - 3 To ncLength - 1
                    newnclines(j) = nclines(i)
                    j += 1
                Next i

                ReDim Preserve newnclines(j)

                'Me.Richtextbox1.Lines = newnclines
                rewritetextbox(newnclines)
                Me.scanfile()
                dynjeton = True



            End If

        End Sub 'mnudynjetonoff_Click

        Private Sub mnudefsettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudefsettings.Click
            Me.load_info_file(stdefdir)
        End Sub

        Private Sub mnu_const_target_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuconstd.Click
            mnuconstd.Checked = True
            mnu2dpts.Checked = False
            mnudxfin.Checked = False
            mnudxfpoints.Checked = False
            targetSurfaceOK = False
            targetsurfacetype = surfacetype.constant
            refreshpanel(3, CStr(nom_depth))
        End Sub 'mnuconstd_Click

        Private Sub mnu_dxf_region_target_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudxfin.Click
            Dim openfiledialog1 As New OpenFileDialog
            Dim surfin As New surfacefile
            Dim dxfreadok As Boolean
            Dim i As Integer
            mnuconstd.Checked = False
            mnu2dpts.Checked = False
            mnudxfin.Checked = True
            mnudxfpoints.Checked = False
            targetsurfacetype = surfacetype.dxfregions
            openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
            openfiledialog1.FilterIndex = 1
            openfiledialog1.Title = "Open Target File"
            Try
                If openfiledialog1.ShowDialog() = DialogResult.OK Then

                    If surfin.dxfregioninput(openfiledialog1.FileName, pointcount, regioncount) Then

                        Dim r As Integer = regionpoint.GetUpperBound(0)
                        For i = 0 To r
                            targetregionpoint(i) = regionpoint(i)
                        Next
                        shorttargetfilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(3, shorttargetfilename)
                    Else
                        dxfreadok = False
                    End If

                    targetSurfaceOK = False

                    If Not dxfreadok Or pointcount <= 0 Or regioncount <= 0 Then
                        MessageBox.Show("DXF region file not read correctly")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:dxf_region_target_depth")
            End Try



        End Sub 'mnudxfin_Click

        Private Sub mnu_csv_target_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2dpts.Click
            Dim surfin As New surfacefile
            Dim openfiledialog1 As New OpenFileDialog
            Dim surfinok As Boolean

            mnuconstd.Checked = False
            mnu2dpts.Checked = True
            mnudxfin.Checked = False
            mnudxfpoints.Checked = False


            targetsurfacetype = surfacetype.csvpoints

            openfiledialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            openfiledialog1.FilterIndex = 1
            openfiledialog1.Title = "Open Target File"
            Try
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    targetSurfaceOK = False

                    If surfin.readcsvsurffile(fileType.targetDepth, openfiledialog1.FileName) Then
                        ReDim ttargetsurface(tsurface.GetUpperBound(0), tsurface.GetUpperBound(1))
                        fillarray(ttargetsurface, tsurface, surfinok)
                        shorttargetfilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(3, shorttargetfilename)
                    Else
                        surfinok = False
                    End If

                End If
                If Not surfinok Then
                    MessageBox.Show("CSV point file not read correctly")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:csv_target_depth")
            End Try

        End Sub 'mnu2dpts_Click

        Private Sub mnu_dxf_point_target_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudxfpoints.Click
            Dim surfin As New surfacefile
            Dim openfiledialog1 As New OpenFileDialog
            Dim surfinok As Boolean

            mnuconstd.Checked = False
            mnu2dpts.Checked = False
            mnudxfin.Checked = False
            mnudxfpoints.Checked = True

            targetsurfacetype = surfacetype.dxfpoints

            openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
            openfiledialog1.FilterIndex = 1
            openfiledialog1.Title = "Open Target File"
            Try
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    targetSurfaceOK = False

                    If surfin.readDxfSurfFile(fileType.targetDepth, openfiledialog1.FileName) Then
                        ReDim ttargetsurface(tsurface.GetUpperBound(0), tsurface.GetUpperBound(1))
                        fillarray(ttargetsurface, tsurface, surfinok)
                        shorttargetfilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(3, shorttargetfilename)
                    Else
                        surfinok = False
                    End If
                    If Not surfinok Then
                        MessageBox.Show("DXF point file not read correctly")
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:dxf_point_target_depth")
            End Try

        End Sub 'mnudxfpoints_Click

        Private Sub mnu_nc_dxf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuncdxf.Click
            Dim savefiledialog1 As New SaveFileDialog
            Dim dxfin As New DXFfile

            If ncfilename <> "" Then
                filename = ncfilename.Remove(ncfilename.LastIndexOf("."), ncfilename.Length - ncfilename.LastIndexOf("."))
                dxffilename = filename & ".nc.dxf"
                savefiledialog1.Filter = "DXF Files(*.dxf)|*.dxf"
                savefiledialog1.FileName = dxffilename
                savefiledialog1.AddExtension = True
                Try
                    read_nc(nclines, istartrow, ifirstrow, ilastrow, dynjeton, vscaling)
                    Me.rewritetextbox(nclines)
                    xydistance()
                    ' get the file name to save the list view information in from the standard save dialog
                    If savefiledialog1.ShowDialog() = DialogResult.OK Then
                        dxfin.dxflinenumbers(savefiledialog1.FileName)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString() & "sub:mnuncdxf_Click")
                End Try
            End If
        End Sub 'mnuncdxf_Click

        Private Sub mnu_save_parms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusaveparms.Click
            If parameters_loaded Then save_parm_file(infofilename)
        End Sub

        Private Sub mnu_save_dxf_surf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusavedxfsurf.Click
            If model_run_success Then
                save_dxf_surf_file(dxffilename, surface, target_surface, outputmesh, _
                 mesh_size, ccomp, pathmin_x, pathmin_y, 0, depth_tolerance, material_thickness)
            End If

        End Sub

        Private Sub mnu_save_csv_surf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnusavecsvsurf.Click
            If model_run_success Then save_csv_surf_file("X,Y,Z", surfacefilename, surface, outputmesh, mesh_size)
        End Sub 'mnusavecsvsurf_Click

        Private Sub mnu_options_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuoptions.Click
            Dim prefs As New preferences
            If prefs.ShowDialog = DialogResult.OK Then
                'Me.dxfoption.Checked = dxfpref
                'Me.surfoption.Checked = csvpref
            End If
        End Sub

        Private Sub mnu_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuhelp.Click
            Dim help As Help = New Help
            help.ShowDialog()
        End Sub

        Private Sub mnu_const_start_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuconstantstartdepth.Click
            mnuconstantstartdepth.Checked = True
            mnudxfregionstartdepth.Checked = False
            mnucsvstartdepth.Checked = False
            mnudxfpointstartdepth.Checked = False
            startsurfacetype = surfacetype.constant
            startSurfaceOK = False
            refreshpanel(2, "0.000")
        End Sub

        Private Sub mnu_dxf_region_start_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudxfregionstartdepth.Click
            Try

                Dim openfiledialog1 As New OpenFileDialog
                Dim surfin As New surfacefile
                Dim dxfreadok As Boolean
                Dim i As Integer
                mnuconstantstartdepth.Checked = False
                mnudxfregionstartdepth.Checked = True
                mnucsvstartdepth.Checked = False
                mnudxfpointstartdepth.Checked = False
                startsurfacetype = surfacetype.dxfregions
                openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open Start File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    startSurfaceOK = False
                    If surfin.dxfregioninput(openfiledialog1.FileName, pointcount, regioncount) Then
                        Dim r As Integer = regionpoint.GetUpperBound(0)
                        For i = 0 To r
                            startregionpoint(i) = regionpoint(i)
                        Next

                    End If
                    If Not dxfreadok Or pointcount <= 0 Or regioncount <= 0 Then
                        MessageBox.Show("DXF region file not read correctly")
                    Else
                        shortstarttargetfilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(2, shortstarttargetfilename)
                    End If
                End If




            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:dxf_region_start_depth")
            End Try

        End Sub

        Private Sub mnu_csv_start_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucsvstartdepth.Click
            Try
                Dim surfin As New surfacefile
                Dim openfiledialog1 As New OpenFileDialog
                Dim surfinok As Boolean
                mnuconstantstartdepth.Checked = False
                mnudxfregionstartdepth.Checked = False
                mnucsvstartdepth.Checked = True
                mnudxfpointstartdepth.Checked = False
                startsurfacetype = surfacetype.csvpoints
                openfiledialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open Start File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then

                    startSurfaceOK = False

                    If surfin.readcsvsurffile(fileType.startDepth, openfiledialog1.FileName) Then
                        ReDim tstartsurface(tsurface.GetUpperBound(0), tsurface.GetUpperBound(1))
                        fillarray(tstartsurface, tsurface, surfinok)

                    End If
                    If Not surfinok Then
                        MessageBox.Show("CSV point file not read correctly")
                    Else
                        shortstarttargetfilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(2, shortstarttargetfilename)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:csv_start_depth")
            End Try


        End Sub

        Private Sub mnu_dxf_point_start_depth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnudxfpointstartdepth.Click
            Try
                Dim surfin As New surfacefile
                Dim openfiledialog1 As New OpenFileDialog
                Dim surfinok As Boolean
                mnuconstantstartdepth.Checked = False
                mnudxfregionstartdepth.Checked = False
                mnucsvstartdepth.Checked = False
                mnudxfpointstartdepth.Checked = True
                startsurfacetype = surfacetype.dxfpoints
                openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open Start File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    startSurfaceOK = False
                    If surfin.readDxfSurfFile(fileType.startDepth, openfiledialog1.FileName) Then
                        ReDim tstartsurface(tsurface.GetUpperBound(0), tsurface.GetUpperBound(1))
                        fillarray(tstartsurface, tsurface, surfinok)

                    End If
                    If Not surfinok Then
                        MessageBox.Show("DXF point file not read correctly")
                    Else
                        shortstarttargetfilename = getshortfilename(openfiledialog1.FileName) '.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                        refreshpanel(2, shortstarttargetfilename)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:dxf_point_start_depth")
            End Try


        End Sub 'mnu_dxf_point_start_depth_Click

        Private Sub mnuConstantMi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConstantMi.Click
            miSurfaceOK = False
            mnuConstantMi.Checked = True
            mnuDxfMi.Checked = False
            mnuCsvMi.Checked = False
            miSurfaceType = surfacetype.constant
            refreshpanel(6, "Constant=1")
        End Sub

        Private Sub mnuCsvMi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCsvMi.Click
            Try
                Dim surfin As New surfacefile
                Dim openfiledialog1 As New OpenFileDialog
                Dim surfInputOK As Boolean
                miSurfaceOK = False
                mnuConstantMi.Checked = False
                mnuDxfMi.Checked = False
                mnuCsvMi.Checked = True
                miSurfaceType = surfacetype.csvpoints

                openfiledialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open MI File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    miSurfaceOK = False
                    surfInputOK = (surfin.readcsvsurffile(inputFile.mi, openfiledialog1.FileName))

                    If Not (surfInputOK) Then
                        MessageBox.Show("CSV point file not read correctly")
                    Else
                        shortMiFileName = getshortfilename(openfiledialog1.FileName)
                        refreshpanel(6, shortMiFileName)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in mnuCsvMi_Click")
            End Try

        End Sub

        Private Sub mnuDxfMi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDxfMi.Click
            Try
                Dim surfin As New surfacefile
                Dim openfiledialog1 As New OpenFileDialog
                Dim surfInputOK As Boolean

                mnuConstantMi.Checked = False
                mnuDxfMi.Checked = True
                mnuCsvMi.Checked = False
                miSurfaceType = surfacetype.dxfpoints

                openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open MI File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    miSurfaceOK = False
                    surfInputOK = (surfin.readDxfSurfFile(inputFile.mi, openfiledialog1.FileName))

                    If Not (surfInputOK) Then
                        MessageBox.Show("DXF point file not read correctly")
                    Else

                        shortMiFileName = getshortfilename(openfiledialog1.FileName)
                        refreshpanel(6, shortMiFileName)
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in  mnuDxfMi_Click")
            End Try
        End Sub
        Private Sub mnuNoMask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNoMask.Click
            maskSurfaceOK = False
            maskSurfaceType = mdmodel.surfacetype.constant
            mnuNoMask.Checked = True
            mnuDxfMaskPontFile.Checked = False
            refreshpanel(5, "None")
        End Sub
        Private Sub mnuDxfMaskPontFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDxfMaskPontFile.Click
            'loads mask dxf point file to define areas of mask
            'into maskSurface
            Try
                Dim surfin As New surfacefile
                Dim openfiledialog1 As New OpenFileDialog
                Dim surfInputOK As Boolean
                openfiledialog1.Filter = "DXF files (*.dxf)|*.dxf|All files (*.*)|*.*"
                openfiledialog1.FilterIndex = 1
                openfiledialog1.Title = "Open Mask File"
                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    maskSurfaceOK = False
                    mnuNoMask.Checked = False
                    mnuDxfMaskPontFile.Checked = True
                    maskSurfaceType = mdmodel.surfacetype.dxfpoints
                    surfInputOK = surfin.readDxfSurfFile(inputFile.mask, openfiledialog1.FileName)
                End If

                If Not (surfInputOK) Then
                    MessageBox.Show("DXF point file not read correctly")
                Else

                    shortMaskFileName = getshortfilename(openfiledialog1.FileName)
                    refreshpanel(5, shortMaskFileName)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in mnuDxfMaskPontFile_Click")
            End Try
        End Sub '            mnuDxfMaskPontFile_Click
#End Region
#Region " Picture box code "
        Sub clearpicturebox1()
            Dim myBrush As New SolidBrush(Color.White)
            bit = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
            Dim g As Graphics = PictureBox1.CreateGraphics
            g.FillRectangle(myBrush, 0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height)
            Me.PictureBox1.Image = bit
            ' myBrush.Dispose()

        End Sub
        Sub clearpicturebox2()
            Dim myBrush As New SolidBrush(Color.White)
            bit = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
            Dim g As Graphics = PictureBox2.CreateGraphics
            g.FillRectangle(myBrush, 0, 0, Me.PictureBox2.Width, Me.PictureBox2.Height)
            Me.PictureBox2.Image = bit
            Me.xsectiondrawn = False
            '
            'myBrush.Dispose()
        End Sub
        Private Sub calcpicturescalef(ByVal display As displaytransform, ByVal input As displaytransform, ByRef output As displaytransform)
            Dim xscale, yscale As Double
            Dim temp As displaytransform
            If input.Equals(zoomextents) And Not (display.Equals(pagedisplay)) Then
                output.X = zoomextents.X
                output.Y = zoomextents.Y

                output.xscalefactor = zoomextents.xscalefactor
                output.yscalefactor = zoomextents.yscalefactor
                output.Height = zoomextents.Height
                output.Width = zoomextents.Width
            ElseIf display.Equals(pagedisplay) Then
                xscale = display.Width / input.Width
                yscale = display.Height / input.Height
                output.xscalefactor = Math.Min(xscale, yscale)
                output.yscalefactor = -1 * output.xscalefactor
                output.X = display.X
                output.Y = display.Height
            ElseIf panactive Then
                output.X = output.X + input.X
                output.Y = output.Y + input.Y

            Else

                If input.Width <> 0 And input.Height <> 0 Then
                    xscale = display.Width / input.Width
                    yscale = display.Height / input.Height
                Else
                    xscale = input.xscalefactor
                    yscale = input.yscalefactor
                    xscale = 1
                    yscale = 1
                    input.X = output.X
                    input.Y = output.Y
                End If

                output.xscalefactor = output.xscalefactor * Math.Min(xscale, yscale)
                output.yscalefactor = -1 * output.xscalefactor

                output.X = input.X
                output.Y = input.Y

            End If

            zoomwindow = output


        End Sub 'calcpicturescalef
        Function updatelegend()
            If depthmap Then
                toodeep.Text = Math.Round(max_depth, 3) & "<d<" & Math.Round(material_thickness, 3)
                tooshal.Text = "d<" & Math.Round(min_depth, 3)
                intoler.Text = Math.Round(min_depth, 3) & "<d<" & Math.Round(max_depth, 3)
                thrupart.Text = "d>=" & Math.Round(material_thickness, 3)
            Else
                tooshal.Text = "fr<" & Math.Round(machine.maxspeed * 0.33, 3)
                intoler.Text = Math.Round(machine.maxspeed * 0.33, 3) & "<fr<" & Math.Round(machine.maxspeed * 0.66, 3)
                toodeep.Text = Math.Round(machine.maxspeed * 0.66, 3) & "<fr<" & Math.Round(machine.maxspeed, 3)
                thrupart.Text = "fr>=" & Math.Round(machine.maxspeed, 3)
            End If

        End Function

        Private Sub displaypicture(ByRef gd As Graphics, ByVal ft As displaytransform, ByVal bbrsh As Brush, ByVal gbrsh As Brush, _
                            ByVal ybrsh As Brush, ByVal rbrsh As Brush, ByVal blkbrsh As Brush)
            Try
                Dim rectsize As Integer
                Dim i, i0, j0, i1, j1, j, x, y, xp, yp, xpp, ypp, x3, y3, yppp As Integer
                Dim x1, x2, y2, y1 As Double
                Dim sp As Integer = 10
                Dim lw As Integer = 5
                Dim sx, sy As String
                Dim fr, fr1, fr2, fr3, fr4, frrange As Double
                Dim printFont As Font = Me.Richtextbox1.Font
                Dim fontheight As Integer = Me.Richtextbox1.Font.Height
                Dim minDepth, maxDepth, targetDepth
                sp = fontheight
                lw = CInt(fontheight / 2)

                If Math.Abs(ft.xscalefactor) <= 1 Or Math.Abs(ft.yscalefactor) <= 1 Then
                    rectsize = 1
                Else
                    rectsize = CInt((ft.xscalefactor * 1) + 1)
                End If

                If Not (ft.Equals(fittopage)) Then
                    i0 = screentoarray(0, ft.xscalefactor, ft.X)
                    j0 = screentoarray(PictureBox1.Height, ft.yscalefactor, ft.Y)
                    i1 = screentoarray(PictureBox1.Width, ft.xscalefactor, ft.X)
                    j1 = screentoarray(0, ft.yscalefactor, ft.Y)
                Else
                    i0 = 0
                    j0 = 0
                    i1 = size_xarray - 1
                    j1 = size_yarray - 1
                End If
                If depthmap Then 'display depth map

                    For i = Math.Max(i0, 0) To Math.Min(i1, size_xarray - 1)
                        For j = Math.Max(j0, 0) To Math.Min(j1, size_yarray - 1)
                            d = Math.Round(Math.Abs(surface(i, j)), 3)

                            If d <> Math.Round(Math.Abs(start_surface(i, j)), 3) Then
                                minDepth = Math.Round(Math.Abs(target_surface(i, j)) - depth_tolerance, 3)
                                maxDepth = Math.Round(Math.Abs(target_surface(i, j)) + depth_tolerance, 3)
                                targetDepth = Math.Round(Math.Abs(target_surface(i, j)), 3)
                                x = arraytoscreen(i, ft.xscalefactor, ft.X)
                                y = arraytoscreen(j, ft.yscalefactor, ft.Y)
                                If d < Math.Round(Math.Abs(target_surface(i, j)) - 2 * depth_tolerance, 3) Then
                                    gd.FillRectangle(bbrsh, x, y, rectsize, rectsize)
                                ElseIf d >= Math.Round(Math.Abs(target_surface(i, j)) - 2 * depth_tolerance, 3) And d < minDepth Then
                                    gd.FillRectangle(blueGreenBrush, x, y, rectsize, rectsize)
                                ElseIf d >= minDepth And d < targetDepth Then
                                    gd.FillRectangle(gbrsh, x, y, rectsize, rectsize)
                                ElseIf d >= targetDepth And d < maxDepth Then
                                    gd.FillRectangle(greenYellowBrush, x, y, rectsize, rectsize)
                                ElseIf d >= maxDepth And d < Math.Round(Math.Abs(target_surface(i, j)) + 2 * depth_tolerance, 3) Then
                                    gd.FillRectangle(yellowBrush, x, y, rectsize, rectsize)
                                ElseIf d >= Math.Round(Math.Abs(target_surface(i, j)) + 2 * depth_tolerance, 3) And d < material_thickness Then
                                    gd.FillRectangle(orangeBrush, x, y, rectsize, rectsize)
                                ElseIf d >= material_thickness Then
                                    gd.FillRectangle(rbrsh, x, y, rectsize, rectsize)
                                End If
                            End If
                        Next
                    Next
                Else ' display feedrate map
                    fr3 = machine.maxspeed
                    'fr3 = fr4 * 0.75
                    fr2 = fr3 * 0.66
                    fr1 = fr3 * 0.33
                    For i = 0 To toolpath.GetUpperBound(0) - 1
                        fr = toolpath(i).f
                        x = arraytoscreen(getxindex(toolpath(i).x, mesh_size, ccomp, pathmin_x), ft.xscalefactor, ft.X)
                        y = arraytoscreen(getyindex(toolpath(i).y, mesh_size, ccomp, pathmin_y), ft.yscalefactor, ft.Y)
                        xp = arraytoscreen(getxindex(toolpath(i + 1).x, mesh_size, ccomp, pathmin_x), ft.xscalefactor, ft.X)
                        yp = arraytoscreen(getyindex(toolpath(i + 1).y, mesh_size, ccomp, pathmin_y), ft.yscalefactor, ft.Y)
                        If fr < fr1 Then
                            gd.DrawLine(bluepen, x, y, xp, yp)
                        ElseIf fr >= fr1 And fr < fr2 Then
                            gd.DrawLine(greenpen, x, y, xp, yp)
                        ElseIf fr >= fr2 And fr < fr3 Then
                            gd.DrawLine(yellowpen, x, y, xp, yp)
                        ElseIf fr >= fr3 Then
                            gd.DrawLine(redpen, x, y, xp, yp)
                        End If
                        If ft.xscalefactor > 2 Then gd.DrawEllipse(blackpen, x - 1, y - 1, 2, 2)
                    Next
                End If

                x1 = getxlocation(0, mesh_size, ccomp, pathmin_x) 'surface x0 
                y1 = getylocation(0, mesh_size, ccomp, pathmin_y) 'surface y0
                x2 = getxlocation(size_xarray, mesh_size, ccomp, pathmin_x) 'surface xmax
                y2 = getylocation(size_yarray, mesh_size, ccomp, pathmin_y) 'surface ymax

                x = arraytoscreen(0, ft.xscalefactor, ft.X)
                y = arraytoscreen(0, ft.yscalefactor, ft.Y)
                xp = arraytoscreen(size_xarray, ft.xscalefactor, ft.X)
                yp = arraytoscreen(size_yarray, ft.yscalefactor, ft.Y)

                x3 = arraytoscreen(CInt(size_xarray / 2), ft.xscalefactor, ft.X)
                y3 = arraytoscreen(CInt(size_yarray / 2), ft.yscalefactor, ft.Y)

                ypp = CInt(y3 - (fontheight / 2))
                yppp = CInt(y + sp / 2)

                sx = CStr(Math.Round((x2 - x1), 3))  'x dimension
                sy = CStr(Math.Round((y2 - y1), 3))  'y dimension

                gd.DrawLine(blackpen, x, y + sp, xp, y + sp) 'xdim line
                gd.DrawLine(blackpen, x, y + sp - lw, x, y + sp + lw) 'xdim witness 
                gd.DrawLine(blackpen, xp, y + sp - lw, xp, y + sp + lw) 'xdim witness
                gd.FillRectangle(whitebrush, x3, yppp, fontheight * 3, fontheight) ' box
                gd.DrawString(sx, printFont, blkbrsh, x3, CInt(y + sp / 2)) 'x dim label

                gd.DrawLine(blackpen, x - sp, y, x - sp, yp) 'ydim line
                gd.DrawLine(blackpen, x - sp - lw, y, x - sp + lw, y) 'ydim witness
                gd.DrawLine(blackpen, x - sp - lw, yp, x - sp + lw, yp) 'ydim witness
                gd.FillRectangle(whitebrush, x - sp * 2, ypp, fontheight * 2, fontheight) ' box
                gd.DrawString(sy, printFont, blkbrsh, x - sp * 2, ypp) 'ydim label

                gd.FillRectangle(blueBrush, xp + sp * 2, yp, lw, sp)      ' pallete
                gd.FillRectangle(blueGreenBrush, xp + sp * 2, yp + sp, lw, sp)    ' pallete
                gd.FillRectangle(greenBrush, xp + sp * 2, yp + sp * 2, lw, sp)  ' pallete
                gd.FillRectangle(yellowBrush, xp + sp * 2, yp + sp * 3, lw, sp)  ' pallete
                gd.FillRectangle(orangeBrush, xp + sp * 2, yp + sp * 4, lw, sp)  ' pallete
                gd.FillRectangle(redBrush, xp + sp * 2, yp + sp * 5, lw, sp)     ' pallete
                If Not (ft.Equals(fittopage)) Then Me.PictureBox1.Image = bit

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:displaypicture")
            End Try

        End Sub 'displaypicture


        Public Function arraytoscreen(ByVal k As Integer, ByVal scale As Double, ByVal offset As Integer) As Integer
            arraytoscreen = CInt((k * scale) + offset)
        End Function

        Public Function screentoarray(ByVal k As Integer, ByVal scale As Double, ByVal offset As Integer) As Integer
            screentoarray = CInt((k - offset) / scale)
        End Function

        Private Sub displaytoolpath(ByVal g As Graphics, ByVal ft As displaytransform, ByVal blckpen As Pen)
            Dim i, j, x, y, xp, yp As Integer

            If model_run_success Then
                Try
                    For i = 0 To toolpath.GetUpperBound(0) - 1
                        x = arraytoscreen(getxindex(toolpath(i).x, mesh_size, ccomp, pathmin_x), ft.xscalefactor, ft.X)
                        y = arraytoscreen(getyindex(toolpath(i).y, mesh_size, ccomp, pathmin_y), ft.yscalefactor, ft.Y)
                        xp = arraytoscreen(getxindex(toolpath(i + 1).x, mesh_size, ccomp, pathmin_x), ft.xscalefactor, ft.X)
                        yp = arraytoscreen(getyindex(toolpath(i + 1).y, mesh_size, ccomp, pathmin_y), ft.yscalefactor, ft.Y)
                        g.DrawLine(blckpen, x, y, xp, yp)
                        If ft.xscalefactor > 2 Then g.DrawEllipse(blackpen, x - 1, y - 1, 2, 2)
                    Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString() & " displaytoolpath")
                End Try

            End If
        End Sub 'displaytoolpath

        Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
            Dim i, array_x, array_y As Integer

            Dim x As Integer = e.X
            Dim y As Integer = e.Y
            oldx = x
            oldy = y
            dragging = True
            If zoomactive Then
                Dim img2 As Image = New Bitmap(PictureBox1.Image)
                txbrush = New TextureBrush(img2)
                zoomstartx = x
                zoomstarty = y

            End If

            Dim cursorx, cursory, cursord As Double
            If model_run_success Then
                Try
                    If xsectactive And xsectioncount = 0 Then
                        xsectiondrawn = False
                        refreshpicture(zoomwindow)
                        drawpoint(e.X, e.Y)
                        Dim img2 As Image = New Bitmap(PictureBox1.Image)
                        txbrush = New TextureBrush(img2)
                        x0 = e.X
                        y0 = e.Y
                        oldx = x
                        oldy = y
                        xsectpoint0x = screentoarray(e.X, zoomwindow.xscalefactor, zoomwindow.X)
                        xsectpoint0y = screentoarray(e.Y, zoomwindow.yscalefactor, zoomwindow.Y)
                        xsectioncount += 1

                    ElseIf xsectactive And xsectioncount = 1 Then
                        drawpoint(e.X, e.Y)
                        y1 = e.Y
                        x1 = e.X
                        xsectpoint1x = screentoarray(e.X, zoomwindow.xscalefactor, zoomwindow.X)
                        xsectpoint1y = screentoarray(e.Y, zoomwindow.yscalefactor, zoomwindow.Y)
                        drawline(x0, y0, x1, y1)
                        drawsection(xsectpoint0x, xsectpoint0y, xsectpoint1x, xsectpoint1y)
                        xsectioncount = 0
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString() & "PictureBox1_MouseDown")
                End Try
            End If
        End Sub 'PictureBox1_MouseDown
        Function feedrateatarraypoint(ByVal x As Double, ByVal y As Double) As Double
            Dim i, min_i, istart, iend, toolpathend As Integer
            Dim xydist, f As Double
            Dim minxydist As Double = 9.0E+16
            toolpathend = toolpath.GetUpperBound(0)
            For i = 0 To toolpathend
                xydist = (x - toolpath(i).x) ^ 2 + (y - toolpath(i).y) ^ 2
                If xydist < minxydist Then
                    min_i = i
                    minxydist = xydist
                End If
            Next
            If min_i = 0 Then min_i = 1
            i = 1
            Do Until nc(i).n = toolpath(min_i).n
                If nc(i).newf <> 0 Then
                    feedrateatarraypoint = nc(i).newf
                Else
                    feedrateatarraypoint = nc(i).f
                End If
                i += 1
            Loop
            If feedrateatarraypoint = 0 Then feedrateatarraypoint = nc(i + 1).f
        End Function
        Function feedrateatcursor(ByVal x As Double, ByVal y As Double) As Double
            Dim i, min_i, istart, iend, toolpathend As Integer
            Dim xydist, f As Double
            Dim minxydist As Double = 9.0E+16
            toolpathend = toolpath.GetUpperBound(0)
            For i = 0 To toolpathend
                xydist = (x - toolpath(i).x) ^ 2 + (y - toolpath(i).y) ^ 2
                If xydist < minxydist Then
                    min_i = i
                    minxydist = xydist
                End If
            Next
            If min_i = 0 Then min_i = 1
            i = 0
            Me.txtcursorn.Text = "N" & toolpath(min_i).n
            Do Until nc(i).n = toolpath(min_i).n
                i += 1
            Loop
            feedrateatcursor = nc(i).f
            ' If feedrateatcursor = 0 Then feedrateatcursor = nc(i + 1).f
        End Function 'feedrateatcursor

        Private Sub ctxdepthdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxdepthdisplay.Click
            Me.depthx.Text = Me.txtcursorx.Text
            Me.depthy.Text = Me.txtcursory.Text
            mdepthx = CDbl(Me.txtcursorx.Text)
            mdepthy = CDbl(Me.txtcursory.Text)
            Me.curdepth.Text = Me.txtdepthatcursor.Text
        End Sub
        Private Sub ctxjumpnc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxjumpnc.Click
            Dim ncline, i As Integer
            Dim strncline As String
            strncline = Me.txtcursorn.Text
            ncline = Me.Richtextbox1.Find(strncline)
            Me.Richtextbox1.Focus()
            Me.Richtextbox1.Select(ncline, 1)
            Me.Richtextbox1.ScrollToCaret()
            Me.Richtextbox1.Refresh()
        End Sub
        Private Sub ctxdepthmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxdepthmap.Click
            ' display depthmap in picture box 1- default
            depthmap = True
            frmap = False
            Me.ctxfrmap.Checked = False
            Me.ctxdepthmap.Checked = True
            refreshpicture(zoomwindow)
            updatelegend()
        End Sub ' ctxdepthmap_Click

        Private Sub ctxfrmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxfrmap.Click
            ' display feed rate map in picture box 1
            depthmap = False
            frmap = True
            Me.ctxfrmap.Checked = True
            Me.ctxdepthmap.Checked = False
            refreshpicture(zoomwindow)
            updatelegend()
        End Sub 'ctxfrmap_Click
        Private Sub refreshpicture(ByVal inputdisplay As displaytransform)
            Try
                bit = New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
                Dim g As Graphics = Graphics.FromImage(bit)
                ctx1scale.Checked = True
                ctxstretchscale.Checked = False
                Me.calcpicturescalef(screendisplay, inputdisplay, finaltrans)
                Me.displaypicture(g, finaltrans, blueBrush, greenBrush, yellowBrush, redBrush, blackbrush)
                If toolpathshown Then displaytoolpath(g, finaltrans, blackpen)
                clearpicturebox2()
                'bit.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "sub:refreshpicture")
            End Try

        End Sub
        Function setScale(ByVal size_x As Integer, ByVal size_y As Integer) As Double
            setScale = Math.Min(Me.PictureBox1.Width / size_x, Me.PictureBox1.Height / size_y)
        End Function
        'Private Sub refreshpicture2(ByVal inputdisplay As displaytransform)
        '    Try

        '        Dim g As Graphics = Graphics.FromImage(bit)
        '        ctx1scale.Checked = True
        '        ctxstretchscale.Checked = False
        '        Me.calcpicturescalef2(screendisplay, inputdisplay, finaltrans)
        '        Me.displaypicture2(g, finaltrans, blueBrush, greenBrush, yellowBrush, redBrush, blackbrush)
        '        If toolpathshown Then displaytoolpath(g, finaltrans, blackpen)
        '        clearpicturebox2()
        '        'bit.Dispose()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message.ToString & "sub:refreshpicture")
        '    End Try

        'End Sub
        Private Sub ctxtoolpath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxtoolpath.Click
            If ctxtoolpath.Checked = False Then
                toolpathshown = True
                ctxtoolpath.Checked = True
            Else
                toolpathshown = False
                ctxtoolpath.Checked = False

            End If
            nozoom.Height = PictureBox1.Height
            nozoom.Width = PictureBox1.Width
            nozoom.X = zoomwindow.X
            nozoom.Y = zoomwindow.Y
            nozoom.xscalefactor = 1
            nozoom.yscalefactor = 1
            refreshpicture(nozoom)

        End Sub

        Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp

            Dim x As Integer = e.X
            Dim y As Integer = e.Y
            Dim scalefactor, xscalefactor, yscalefactor As Double
            dragging = False
            If panactive Then
                Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.NoMove2D
            End If

            If zoomactive Then
                zoomendx = x
                zoomendy = y

                If zoomendx - zoomstartx <> 0 And zoomendy - zoomstarty <> 0 Then
                    xscalefactor = PictureBox1.Width / Math.Abs(zoomendx - zoomstartx)
                    yscalefactor = PictureBox1.Height / Math.Abs(zoomendy - zoomstarty)
                    scalefactor = Math.Min(xscalefactor, yscalefactor)
                    zoomwindow.xscalefactor = scalefactor
                    zoomwindow.yscalefactor = scalefactor
                    zoomwindow.Width = Math.Abs(zoomendx - zoomstartx)
                    zoomwindow.Height = Math.Abs(zoomendy - zoomstarty)
                    zoomwindow.X = CInt(zoomwindow.xscalefactor * (zoomwindow.X - Math.Min(zoomendx, zoomstartx))) 'ad
                    zoomwindow.Y = CInt(zoomwindow.yscalefactor * (zoomwindow.Y - Math.Min(zoomendy, zoomstarty))) 'ad


                    refreshpicture(zoomwindow)
                End If



            End If

        End Sub 'PictureBox1_MouseUp

        Private Sub drawsection(ByVal i0 As Integer, ByVal j0 As Integer, ByVal i1 As Integer, ByVal j1 As Integer)

            Dim bit2 As Bitmap = New Bitmap(Me.PictureBox2.Width, Me.PictureBox2.Height)
            Dim g2 As Graphics = Graphics.FromImage(bit2)
            Dim sectionlength, l, k, kmax, xd0, yd0, xd1, yd1, id, jd As Integer
            Dim x, y, z, zmin, zmax, dx, dy, x0, y0, x1, y1, xscale, yscale, scale, depthrange, sy, sx As Double
            zmin = 9.0E+20
            zmax = 0
            sectionlength = CInt(Math.Sqrt((i1 - i0) ^ 2 + (j1 - j0) ^ 2))
            If sectionlength <> 0 Then
                pic2yoffset = CInt(PictureBox2.Height * 0.1)
                x0 = getxlocation(i0, mesh_size, ccomp, pathmin_x)
                x1 = getxlocation(i1, mesh_size, ccomp, pathmin_x)
                y0 = getylocation(j0, mesh_size, ccomp, pathmin_y)
                y1 = getylocation(j1, mesh_size, ccomp, pathmin_y)

                dx = x1 - x0
                dy = y1 - y0
                l = CInt(Math.Sqrt(dy ^ 2 + dx ^ 2))
                Dim xs(sectionlength, 5) As Double
                k = 0

                sy = Math.Sin(Math.Atan2(dy, dx))
                sx = Math.Cos(Math.Atan2(dy, dx))
                For k = 0 To sectionlength - 1
                    y = sy * (k * mesh_size) + y0
                    x = sx * (k * mesh_size) + x0
                    id = getxindex(x, mesh_size, ccomp, pathmin_x)
                    jd = getyindex(y, mesh_size, ccomp, pathmin_y)


                    If id < 0 Or id >= size_xarray Or jd < 0 Or jd >= size_yarray Then
                        xs(k, 1) = 0
                    Else
                        xs(k, 1) = surface(id, jd)
                        xs(k, 2) = -1 * Math.Abs(target_surface(id, jd)) + depth_tolerance
                        xs(k, 3) = -1 * Math.Abs(target_surface(id, jd))
                        xs(k, 4) = -1 * Math.Abs(target_surface(id, jd)) - depth_tolerance
                    End If

                    If xs(k, 1) > zmax Then zmax = xs(k, 1)
                    If xs(k, 1) < zmin Then zmin = xs(k, 1)
                    xs(k, 0) = k * mesh_size

                Next

                kmax = k - 1
                depthrange = zmax - zmin
                If depthrange <> 0 Then
                    pic2xscale = (PictureBox2.Width) / Math.Sqrt(dy ^ 2 + dx ^ 2)
                    pic2yscale = (PictureBox2.Height * 0.8) / Math.Abs(depthrange)
                    pic2scale = Math.Min(pic2xscale, pic2yscale)
                    If ctx1scale.Checked Then
                        pic2xscale = pic2scale
                        pic2yscale = pic2scale
                    End If
                    For k = 0 To kmax - 1
                        xd0 = CInt(Math.Abs(pic2xscale * xs(k, 0)))
                        xd1 = CInt(Math.Abs(pic2xscale * xs(k + 1, 0)))
                        yd0 = CInt(Math.Abs(pic2yscale * (xs(k, 1) - zmax)))
                        yd1 = CInt(Math.Abs(pic2yscale * (xs(k + 1, 1) - zmax)))
                        g2.DrawLine(blackpen, xd0, yd0 + pic2yoffset, xd1, yd1 + pic2yoffset)
                        yd0 = CInt(Math.Abs(pic2yscale * (xs(k, 2) - zmax)))
                        yd1 = CInt(Math.Abs(pic2yscale * (xs(k + 1, 2) - zmax)))
                        g2.DrawLine(bluepen, xd0, yd0 + pic2yoffset, xd1, yd1 + pic2yoffset)
                        yd0 = CInt(Math.Abs(pic2yscale * (xs(k, 3) - zmax)))
                        yd1 = CInt(Math.Abs(pic2yscale * (xs(k + 1, 3) - zmax)))
                        g2.DrawLine(greenpen, xd0, yd0 + pic2yoffset, xd1, yd1 + pic2yoffset)
                        yd0 = CInt(Math.Abs(pic2yscale * (xs(k, 4) - zmax)))
                        yd1 = CInt(Math.Abs(pic2yscale * (xs(k + 1, 4) - zmax)))
                        g2.DrawLine(yellowpen, xd0, yd0 + pic2yoffset, xd1, yd1 + pic2yoffset)

                    Next
                    Dim part_d As Integer = CInt(Math.Abs(pic2yscale * material_thickness))
                    Dim xmax As Integer = PictureBox2.Width
                    g2.DrawLine(redpen, 0, part_d + pic2yoffset, xmax, part_d + pic2yoffset)
                    Me.PictureBox2.Image = bit2
                End If

            End If
            'bit2.Dispose()
            xsectiondrawn = True
        End Sub 'drawsection

        Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove

            Dim cursorx, cursory, cursord, cursordnominal, cursorDepthStarting As Double
            Dim cursormi As Double
            Dim cursorMask As Integer
            If dragging And zoomactive Then
                Try
                    Dim bit2 As New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
                    Dim gtemp As Graphics = Graphics.FromImage(bit2)

                    dashpen.DashStyle = DashStyle.Dot

                    gtemp.FillRectangle(txbrush, 0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height)

                    gtemp.DrawRectangle(dashpen, Math.Min(zoomstartx, e.X), Math.Min(zoomstarty, e.Y), Math.Abs(zoomstartx - e.X), Math.Abs(zoomstarty - e.Y))

                    Me.PictureBox1.Image = bit2
                    'bit2.Dispose()
                Catch ex As Exception
                    Debug.WriteLine(ex.Message.ToString() & "PictureBox1_Mousemove_zoom")
                End Try

            End If
            If xsectactive And xsectioncount = 1 Then
                Try
                    Dim bit2 As New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    Dim gtemp As Graphics = Graphics.FromImage(bit2)
                    dashpen.DashStyle = DashStyle.Dot
                    gtemp.FillRectangle(txbrush, 0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height)
                    gtemp.Drawline(dashpen, oldx, oldy, e.X, e.Y)
                    Me.PictureBox1.Image = bit2
                    'bit2.Dispose()
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString() & "PictureBox1_Mousemove_xsect")
                End Try
            End If



            Try
                If dragging And panactive Then

                    Dim deltay As Integer = e.Y - oldy
                    Dim deltax As Integer = e.X - oldx
                    zoomwindow.X = deltax
                    zoomwindow.Y = deltay
                    If deltax > 0 And deltay > 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanSE
                    ElseIf deltax > 0 And deltay < 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanNE
                    ElseIf deltax < 0 And deltay < 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanNW
                    ElseIf deltax < 0 And deltay > 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanSW
                    ElseIf Math.Abs(deltax) < PictureBox1.Width * 0.1 And deltay > 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanSouth
                    ElseIf Math.Abs(deltax) < PictureBox1.Width * 0.1 And deltay < 0 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanNorth
                    ElseIf deltax < 0 And Math.Abs(deltay) < PictureBox1.Height * 0.1 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanWest
                    ElseIf deltax > 0 And Math.Abs(deltay) < PictureBox1.Height * 0.1 Then
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.PanEast
                    End If



                    Me.PictureBox1.Refresh()
                    refreshpicture(zoomwindow) ' removed
                    oldy = e.Y
                    oldx = e.X
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "PictureBox1_Mousemove_pan&drag")
            End Try
            'If model_run_success Then
            Try
                If zoomwindow.xscalefactor <> 0 Then 'And crossactive Then
                    Dim array_x As Integer = screentoarray(e.X, zoomwindow.xscalefactor, zoomwindow.X)
                    Dim array_y As Integer = screentoarray(e.Y, zoomwindow.yscalefactor, zoomwindow.Y)

                    cursorx = getxlocation(array_x, mesh_size, ccomp, pathmin_x)
                    cursory = getylocation(array_y, mesh_size, ccomp, pathmin_y)
                    If array_x > 0 And array_x < size_xarray And array_y > 0 And array_y < size_yarray Then
                        cursorDepthStarting = Math.Abs(start_surface(getxindex(cursorx, mesh_size, ccomp, pathmin_x), getyindex(cursory, mesh_size, ccomp, pathmin_y)))
                        cursord = Math.Abs(surface(getxindex(cursorx, mesh_size, ccomp, pathmin_x), getyindex(cursory, mesh_size, ccomp, pathmin_y)))
                        cursordnominal = Math.Abs(target_surface(getxindex(cursorx, mesh_size, ccomp, pathmin_x), getyindex(cursory, mesh_size, ccomp, pathmin_y)))
                        cursormi = mi_surface(getxindex(cursorx, mesh_size, ccomp, pathmin_x), getyindex(cursory, mesh_size, ccomp, pathmin_y))
                        cursorMask = maskSurface(getxindex(cursorx, mesh_size, ccomp, pathmin_x), getyindex(cursory, mesh_size, ccomp, pathmin_y))
                    Else
                        cursord = 0
                        cursordnominal = 0
                    End If
                    Me.txtCursorMask.Text = CStr((cursorMask))
                    Me.txtDepthStarting.Text = CStr(Math.Round(cursorDepthStarting, 3))
                    Me.txtcursordnom.Text = CStr(Math.Round(cursordnominal, 3))
                    Me.txtdepthatcursor.Text = CStr(Math.Round(cursord, 3))
                    Me.txtcursorx.Text = CStr(Math.Round(cursorx, 3))
                    Me.txtcursory.Text = CStr(Math.Round(cursory, 3))
                    Me.txtcursormi.Text = CStr(Math.Round(cursormi, 3))
                    'If cursord = 0 Then
                    'Me.txtcursorf.Text = "-"
                    'Else
                    Me.txtcursorf.Text = CStr(Math.Round(feedrateatcursor(cursorx, cursory), 2))
                    'End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "PictureBox1_Mousemove")
            End Try
            'End If

        End Sub

        Private Sub pan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pan.Click

            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.NoMove2D

            panactive = True
            zoomactive = False
            xsectactive = False
            crossactive = False

            Me.zoom.BackColor = SystemColors.Control
            Me.pan.BackColor = SystemColors.ActiveCaption
            Me.xsection.BackColor = SystemColors.Control

        End Sub 'pan_Click

        Private Sub crossh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crossh.Click

            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross

            panactive = False
            zoomactive = False
            xsectactive = False
            crossactive = True
            Me.pan.BackColor = SystemColors.Control
            Me.zoom.BackColor = SystemColors.Control
            Me.xsection.BackColor = SystemColors.Control
            Me.crossh.BackColor = SystemColors.ActiveCaption

        End Sub

        Private Sub zoomext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zoomext.Click

            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross

            zoomactive = False
            panactive = False
            xsectactive = False

            Me.zoom.BackColor = SystemColors.Control
            Me.pan.BackColor = SystemColors.Control
            Me.xsection.BackColor = SystemColors.Control

            refreshpicture(zoomextents)
        End Sub

        Private Sub zoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zoom.Click

            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross

            panactive = False
            xsectactive = False
            zoomactive = True
            crossactive = False
            Me.zoom.BackColor = SystemColors.ActiveCaption
            Me.pan.BackColor = SystemColors.Control
            Me.xsection.BackColor = SystemColors.Control
            Me.crossh.BackColor = SystemColors.Control

        End Sub

        Private Sub calczoomexts()

            zoomextents.xscalefactor = Math.Min(PictureBox1.Width / (1.3 * size_xarray), PictureBox1.Height / (1.3 * size_yarray))
            zoomextents.yscalefactor = -1 * zoomextents.xscalefactor

            zoomextents.X = CInt((Me.PictureBox1.Width / 2) - (zoomextents.xscalefactor * size_xarray / 2))
            zoomextents.Y = CInt((Me.PictureBox1.Height / 2) - (zoomextents.yscalefactor * size_yarray / 2))
            zoomextents.Height = Me.PictureBox1.Height
            zoomextents.Width = Me.PictureBox1.Width

            resetzoom()

        End Sub

        Private Sub resetzoom()
            zoomwindow.xscalefactor = 1
            zoomwindow.yscalefactor = 1
            zoomwindow.Width = Me.PictureBox1.Width
            zoomwindow.Height = Me.PictureBox1.Height
            zoomwindow.X = 0
            zoomwindow.Y = 0

        End Sub

        Private Sub xsection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles xsection.Click
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross

            panactive = False
            zoomactive = False
            Me.zoom.BackColor = SystemColors.Control
            Me.pan.BackColor = SystemColors.Control
            xsectactive = True
            Me.xsection.BackColor = SystemColors.ActiveCaption
            Me.crossh.BackColor = SystemColors.Control
            xsectioncount = 0
        End Sub

        Private Sub drawpoint(ByVal x As Integer, ByVal y As Integer)
            Dim gtemp As Graphics = Graphics.FromImage(PictureBox1.Image)
            gtemp.DrawLine(blackpen, x, y - 5, x, y + 5)
            gtemp.DrawLine(blackpen, x - 5, y, x + 5, y)
            Me.PictureBox1.Refresh()
            'End If
        End Sub

        Private Sub drawline(ByVal x0 As Integer, ByVal y0 As Integer, ByVal x1 As Integer, ByVal y1 As Integer)
            Dim gtemp As Graphics = Graphics.FromImage(PictureBox1.Image)
            gtemp.DrawLine(blackpen, x0, y0, x1, y1)
            Me.PictureBox1.Refresh()

        End Sub

        Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
            Dim x, y As Double
            Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Cross
            If xsectiondrawn Then
                y = -1 * ((e.Y - pic2yoffset) / pic2yscale)
                x = e.X / pic2xscale
                Me.txtxsectdepth.Text = CStr(Math.Round(y, 4))
                Me.txtxsectpos.Text = CStr(Math.Round(x, 4))
            End If
        End Sub

        Private Sub ctx1scale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctx1scale.Click
            If xsectiondrawn Then
                If ctxstretchscale.Checked Then
                    ctx1scale.Checked = True
                    ctxstretchscale.Checked = False
                    drawsection(xsectpoint0x, xsectpoint0y, xsectpoint1x, xsectpoint1y)
                End If


            End If
        End Sub

        Private Sub ctxstretchscale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxstretchscale.Click
            If xsectiondrawn Then
                If ctx1scale.Checked Then
                    ctxstretchscale.Checked = True
                    ctx1scale.Checked = False
                    drawsection(xsectpoint0x, xsectpoint0y, xsectpoint1x, xsectpoint1y)
                End If


            End If
        End Sub


#End Region
#Region "Text box Context menu code "
        Private Sub ctxdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxdelete.Click
            delete()
        End Sub

        Private Sub ctxcut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxcut.Click
            cut()
        End Sub


        Private Sub ctxpaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxpaste.Click
            paste()
        End Sub



        Private Sub ctxcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxcopy.Click
            copy()
        End Sub

#End Region

        Protected Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            'check for unsaved data
            If checkUnSavedData() = False Then
                e.Cancel = True
                Return
            End If
        End Sub 'Form1_Closing

        Protected Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Richtextbox1.TextChanged
            blnSaveChkFlag = True
        End Sub 'textBox1_TextChanged

        Sub scanfile()
            Try
                Dim a, i, b As Integer
                Dim comm As Boolean
                Dim strline, strccomp As String
                Dim dccomp As Double
                refreshpanel(1, "Scanning File")


                nclines = Me.Richtextbox1.Lines
                nccode.Clear()
                loadxmlmachineinfo()
                machine = Nothing
                fileloaded = False
                model_run_success = False
                dynjeton = False
                vscaling = False
                lastrowfound = False
                firstrowfound = False
                startlocationfound = False
                machine_name_found = False
                ccompfound = False
                ifirstrow = 0
                istart = 0
                ilastrow = 90000000
                istartrow = 0
                icommentcount = 0
                ilength = 0
                a = 0
                For i = 0 To nclines.GetUpperBound(0)
                    strline = nclines(i)
                    If fileloaded = False Then scannc(strline, a, ifirstrow, ilastrow, istartrow, icommentcount, strccomp)
                    a += 1
                Next
                If machine.name = "" Then
                    MessageBox.Show("Cannot find machine name")
                    fileloaded = False
                ElseIf (ifirstrow = 0 And ilastrow = 0 And istartrow = 0) Then
                    MessageBox.Show("File is not a recognized NC format.")
                    fileloaded = False
                ElseIf firstrowfound = False Then
                    MessageBox.Show("cannot find " & machine.startstring)

                ElseIf startlocationfound = False Then
                    MessageBox.Show("cannot find " & machine.jetonstring)

                ElseIf lastrowfound = False Then
                    MessageBox.Show("cannot find " & machine.endstring)

                Else
                    ilength = ilastrow - ifirstrow - (icommentcount - 1)
                    istartrow = istartrow - 1

                    ilastrow = ilastrow - 1
                    If ilength > 1 And fileloaded Then
                        If IsNumeric(strccomp) Then
                            dccomp = Val(strccomp)
                            ccomp = dccomp
                        Else
                            ccomp = 0
                        End If
                        If ccomp <> ccomp_old Then
                            invalidateSurfaces()


                        End If
                        ccomp_old = ccomp

                        ncmachine = machine.name


                        ReDim nc(ilength)
                    End If
                End If
                Runmodel.Enabled = True


                refreshpanel(1, "File Complete")

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:scanfile")
            End Try


        End Sub 'scanfile
        Private Sub invalidateSurfaces()
            startSurfaceOK = False
            targetSurfaceOK = False
            miSurfaceOK = False
            maskSurfaceOK = False
            surfaceOK = False
        End Sub

        Private Sub scannc(ByVal linetoread As String, ByRef linepos As Integer, _
                           ByRef firstrow As Integer, ByRef lastrow As Integer, _
                           ByRef startlocation As Integer, ByRef commentcount As Integer, _
                            ByRef ccomp As String)
            Static lastline As String
            Static firstjeton, jeton As Boolean
            Static firstrowoffset, length As Integer
            Dim tpos, rptpos, erppos As Integer
            Dim i As Integer
            'scan nc file to get length and machine type
            'length and machine type is used to set array length and machine accel values

            ' firstrow = first motion nc line
            'lastrow= last motion nc line
            linetoread = linetoread.Trim
            Try
                If machine_name_found = False Then

                    For i = 0 To machinemax
                        If linetoread.StartsWith(machinedata(i).machinetag) Then
                            machine = machinedata(i)
                            machinenumber = i
                            machine_name_found = True
                        End If
                    Next
                End If

                If machine_name_found Then

                    If machine.toolstring <> Nothing Then
                        tpos = InStr(linetoread, machine.toolstring, CompareMethod.Text)
                    End If
                    If machine.repeatstart <> Nothing Then
                        rptpos = InStr(linetoread, machine.repeatstart, CompareMethod.Text)
                    End If
                    If machine.repeatstop <> Nothing Then
                        erppos = InStr(linetoread, machine.repeatstop, CompareMethod.Text)
                    End If
                    Dim expos As Integer = InStr(linetoread, "!", CompareMethod.Text)
                    If firstrow > 0 And lastrow = 90000000 Then
                        If linetoread.StartsWith("/") Or linetoread.StartsWith(machine.machinecomment) Or erppos > 0 Or rptpos > 0 Then
                            commentcount += 1
                        End If
                        If expos > 0 Then
                            If linetoread.Substring(expos - 1, 3) = "!V=" Then
                                commentcount += 1
                                vscaling = True
                            End If
                        End If
                    End If
                    If ccompfound = False Then
                        If linetoread.StartsWith(machine.ccompstring) Then
                            ccomp = linetoread.Substring(linetoread.IndexOf("P") + 1)
                            ccomp = ccomp.Trim()
                            ccomp = ccomp.Trim(machine.machinecommentend)
                            ccompfound = True
                        End If
                    End If

                    'find cutter comp value
                    'find jeton string location
                    If linetoread.StartsWith(machine.jetonstring) Then
                        startlocation = linepos
                        startlocationfound = True
                    End If
                    'find start string location
                    If linetoread.StartsWith(machine.startstring) Then
                        firstrow = linepos + firstrowoffset + 1
                        firstrowfound = True
                    End If
                    'find end string location
                    If linetoread.StartsWith(machine.endstring) Then
                        lastrow = linepos
                        lastrowfound = True
                        fileloaded = True
                    End If
                    'count machine comments
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:scannc")

            End Try


        End Sub 'scannc



        Private Function checkUnSavedData() As Boolean
            If blnSaveChkFlag = True Then
                Dim dlgRes As DialogResult
                dlgRes = MessageBox.Show("The text in the file has changed. Do you want to save changes?", "ABMACHSim", MessageBoxButtons.YesNoCancel)

                Select Case dlgRes
                    Case DialogResult.Yes
                        Dim filesaved As Boolean = SaveFile()
                        Return filesaved
                    Case DialogResult.No
                        blnSaveChkFlag = False
                        Return True
                    Case DialogResult.Cancel
                        Return False
                End Select
            End If
            Return True
        End Function 'checkUnSavedData


        Private Sub SaveSettings()
            'Note I am not saving all properties of Font
            Try
                'Save final setting of notepad			
                Dim reKSubKey As RegistryKey = Registry.LocalMachine
                reKSubKey.CreateSubKey("AjitC#")

                'Font related
                reKSubKey.SetValue("FontName", Richtextbox1.Font.FontFamily.GetName(0))
                reKSubKey.SetValue("FontSize", Convert.ToString(Richtextbox1.Font.Size))

            Catch
            End Try
        End Sub 'SaveSettings

        Private Sub GetSettings()
            'Get last saved setting
            Try
                Dim reK As RegistryKey = Registry.LocalMachine
                reK.OpenSubKey("AjitC#")

                Richtextbox1.Font = New System.Drawing.Font(reK.GetValue("FontName").ToString(), Convert.ToSingle(reK.GetValue("FontSize")))
            Catch
            End Try
        End Sub 'GetSettings

        'Entry point which delegates to C-style main Private Function
        ' Public Overloads Shared Sub Main()
        '    Main(System.Environment.GetCommandLineArgs())
        'End Sub
        'Key may not present.Set default values


        Sub refreshpanel(ByVal panel As Integer, ByVal txt As String)
            If panel >= sbplabel.GetLowerBound(0) And panel <= sbplabel.GetUpperBound(0) Then
                sbfrm1.Panels(panel).Text = sbplabel(panel) & txt
                sbfrm1.Refresh()
            End If

        End Sub

        Private Sub modelrun()
            Dim infofileout As New infofile
            Dim surfacefile As New surfacefile
            Dim dxfoutput As New DXFfile
            Dim itercount, iterations, i, j, r, runs, maxdfi, maxi, mini, sr, sc As Integer
            Dim validdata As Boolean 'startSurfaceOK, targetSurfaceOK, miSurfaceOK
            Dim tot_path_l, currentdepth, targetz As Double
            Dim newmrr As Decimal
            Static runversion As Integer
            Try

                If Not (ncfilename Is Nothing) Then
                    disablepicture()
                    scanfile()
                    starttime = Now
                    model_run_success = False
                    surfaceOK = False
                    validdata = True
                    'validate data input
                    If Not (IsNumeric(runnumber.Text)) Or Not (IsNumeric(iterationnumber.Text)) Then
                        MessageBox.Show("Enter valid numbers for runs and iterations")
                        validdata = False
                    End If
                    If Not ((IsNumeric(depthn.Text)) Or ((IsNumeric(depthy.Text)) And (IsNumeric(depthx.Text)))) Then

                        MessageBox.Show("Enter valid data for a depth measurement location")
                        validdata = False
                    End If

                    If CInt(iterationnumber.Text) < 1 Then
                        MessageBox.Show("Enter valid number of iterations")
                    End If

                    If validdata And fileloaded Then


                        starttime = starttime.Now
                        runmodelstart = True

                        refreshpanel(1, "Initializing Model")
                        runversion += 1
                        total_segments = 0
                        iterations = CInt(iterationnumber.Text)
                        runs = CInt(runnumber.Text)
                        numberruns = runs
                        'start model run
                        'call redim arrays
                        mrrxmlselect(mrrtype)
                        initialize(runs)
                        filename = ncfilename.Remove(ncfilename.LastIndexOf("."), ncfilename.Length - ncfilename.LastIndexOf("."))
                        dxffilename = filename & ".mod.v" & runversion & ".dxf"
                        infofilename = filename & ".info.v" & runversion & ".prx"
                        surfacefilename = filename & ".mod.v" & runversion & ".csv"
                        targetfilename = filename & ".target.v" & runversion & ".dxf"
                        temptargetfilename = filename & ".inputsurf.v" & runversion & ".dxf"
                        toolpathfilename = filename & ".tp.csv"
                        ncmodelfilename = filename & ".nc.csv"
                        starttargetfilename = filename & ".startsurf.v" & runversion & ".dxf"
                        miFileName = filename & ".mi.v" & runversion & ".dxf"
                        Dim tmifilename As String = filename & ".tmi.v" & runversion & ".dxf"
                        Dim miCsvFilename As String = filename & ".mi.v" & runversion & ".csv"
                        ReDim nc(ilength)

                        read_nc(nclines, istartrow, ifirstrow, ilastrow, dynjeton, vscaling)
                        Me.rewritetextbox(nclines)
                        tot_path_l = calcpathl(ilength)

                        tot_path_pts = CInt((tot_path_l / toolsegmentl) * 3)
                        ReDim toolpath(tot_path_pts)
                        ReDim segmentdepth(tot_path_pts)
                        ReDim depth_display(runs)
                        refreshpanel(1, "Creating surface files")

                        fillarrays(ilength)
                        calc_arrray_size()







                        If Not (surfaceOK) Then
                            ReDim surface(size_xarray, size_yarray) 'model output surface array
                            ReDim tempsurface(size_xarray, size_yarray) 'temp surface array
                            surfaceOK = True
                        End If



                        'calc start surfaces if changed or new
                        If Not (startSurfaceOK) Then
                            ReDim start_surface(size_xarray, size_yarray) 'starting depth array
                            If startsurfacetype = surfacetype.constant Then
                                refreshpanel(2, "0.000")
                                fillarray(start_surface, 0, startSurfaceOK)
                                startSurfaceOK = True
                            End If
                            'If startsurfacetype = surfacetype.constant And targetsurfacetype = mdmodel.surfacetype.constant Then

                            'End If
                            '  create start surface from dxf region file
                            If startsurfacetype = surfacetype.dxfregions Then
                                dxf_to_target_surface(startSurfaceOK, startregionpoint, start_surface)
                                If startSurfaceOK Then
                                    refreshpanel(2, shortstarttargetfilename)
                                    If strpref Then save_dxf_surf_file(starttargetfilename, start_surface, start_surface, outputmesh, mesh_size, ccomp, pathmin_x, pathmin_y, 0, 9.0E+20, material_thickness)

                                Else
                                    If MessageBox.Show("Starting surface not created from DXF file. Start at constant depth=0 ?", "Starting Surface Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                                        refreshpanel(2, "0.000")
                                        fillarray(start_surface, 0, startSurfaceOK)
                                    Else
                                        refreshpanel(1, "Model Run Aborted")
                                        model_run_success = False
                                        runmodelstart = False
                                        Exit Try
                                        'Throw New Exception
                                    End If
                                End If
                            End If

                            'create start surface from csv file or dxf point file
                            If startsurfacetype = surfacetype.csvpoints Or startsurfacetype = surfacetype.dxfpoints Then
                                interpolate2dSurface(startSurfaceOK, startsurfacetype, startExtents, start_surface, tstartsurface)

                                'If Not (miSurfaceOK) Then
                                '    ReDim mi_surface(size_xarray, size_yarray) 'machinability index array
                                '    pointstotarget(miSurfaceOK, inputsurfacetype, mi_surface, tmisurface)

                                'End If
                                If startSurfaceOK Then
                                    If strpref Then save_dxf_surf_file(starttargetfilename, start_surface, start_surface, outputmesh, mesh_size, ccomp, pathmin_x, pathmin_y, 0, 9.0E+20, material_thickness)
                                    refreshpanel(2, shortstarttargetfilename)
                                Else

                                    If MessageBox.Show("Starting surface not created from point file. Start at constant depth=0 ?", "Starting Surface Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                                        refreshpanel(2, "0.000")
                                        fillarray(start_surface, 0, startSurfaceOK)
                                    Else
                                        refreshpanel(1, "Model Run Aborted")
                                        model_run_success = False
                                        runmodelstart = False
                                        Exit Try
                                        'Throw New Exception
                                    End If
                                End If
                            End If
                        End If
                        'calc target surfaces if changed or new
                        If Not (targetSurfaceOK) Then
                            ReDim target_surface(size_xarray, size_yarray) 'target depth array


                            If targetsurfacetype = surfacetype.constant Then
                                refreshpanel(3, nom_depth)
                                fillarray(target_surface, nom_depth, targetSurfaceOK)
                            End If
                            'create target surface from csv file or dxf point file
                            If targetsurfacetype = surfacetype.csvpoints Or targetsurfacetype = surfacetype.dxfpoints Then
                                interpolate2dSurface(targetSurfaceOK, targetsurfacetype, targetExtents, target_surface, ttargetsurface)

                                If targetSurfaceOK Then
                                    If targpref Then save_dxf_surf_file(targetfilename, target_surface, target_surface, outputmesh, mesh_size, ccomp, pathmin_x, pathmin_y, 9.0E+20, 9.0E+20, material_thickness)

                                    refreshpanel(3, shorttargetfilename)
                                Else

                                    If MessageBox.Show("Target surface not created from point file. Converge to constant depth?", "Target Surface Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                                        refreshpanel(3, nom_depth)
                                        fillarray(target_surface, nom_depth, targetSurfaceOK)
                                    Else
                                        refreshpanel(1, "Model Run Aborted")
                                        model_run_success = False
                                        runmodelstart = False
                                        'Throw New Exception
                                        Exit Try
                                    End If


                                End If
                            End If 'end of target surface dxf or csv point check

                            'create target surface from dxf region file
                            If targetsurfacetype = surfacetype.dxfregions Then

                                dxf_to_target_surface(targetSurfaceOK, targetregionpoint, target_surface)
                                If targetSurfaceOK Then
                                    refreshpanel(3, shorttargetfilename)
                                    If targpref Then save_dxf_surf_file(targetfilename, target_surface, target_surface, outputmesh, mesh_size, ccomp, pathmin_x, pathmin_y, 9.0E+20, 9.0E+20, material_thickness)
                                Else
                                    If MessageBox.Show("Target surface not created from DXF file. Converge to constant depth?", "Target Surface Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                                        refreshpanel(3, nom_depth)
                                        fillarray(target_surface, nom_depth, targetSurfaceOK)
                                    Else
                                        refreshpanel(1, "Model Run Aborted")
                                        model_run_success = False
                                        runmodelstart = False
                                        ' Throw New Exception
                                        Exit Try

                                    End If
                                End If
                            End If 'end of target surface dxf region check
                        End If 'end of target surface check

                        'MI surface check
                        If Not (miSurfaceOK) Then
                            ReDim mi_surface(size_xarray, size_yarray) 'machinability index array 
                            If miSurfaceType = surfacetype.constant Then
                                fillarray(mi_surface, 1, miSurfaceOK)
                                'miSurfaceOK = True
                                refreshpanel(6, "Constant=1")
                            ElseIf miSurfaceType = surfacetype.csvpoints Then
                                interpolate2dSurface(miSurfaceOK, miSurfaceType, miExtents, mi_surface, tmisurface)
                                'miSurfaceOK = True
                                refreshpanel(6, shortMiFileName)
                            ElseIf miSurfaceType = surfacetype.dxfpoints Then
                                interpolate2dSurface(miSurfaceOK, miSurfaceType, miExtents, mi_surface, tmisurface)
                                'miSurfaceOK = True
                                refreshpanel(6, shortMiFileName)
                            End If


                        End If
                        'mask surface check
                        If Not (maskSurfaceOK) Then
                            ReDim maskSurface(size_xarray, size_yarray) 'temp surface array
                            If maskSurfaceType <> surfacetype.constant Then
                                interpolate2dSurface(maskSurfaceOK, maskSurfaceType, maskExtents, maskSurface, tMaskSurface)
                                'maskSurfaceOK = True
                                refreshpanel(5, shortMaskFileName)
                            Else
                                fillarray(maskSurface, 1, maskSurfaceOK)
                                'maskSurfaceOK = True
                                refreshpanel(5, "None")
                            End If

                        End If

                        If Not (maskSurfaceOK) Or Not (miSurfaceOK) Then
                            model_run_success = False
                            runmodelstart = False
                            Exit Try
                        End If
                        refreshpanel(1, "Model Running")


                        'start iteration loop

                        curmrr.Text = CStr(depth_per_run)
                        ProgressBar1.Minimum = 0
                        ProgressBar1.Maximum = iterations * runs
                        ProgressBar1.Step = 1

                        If depthn.Text <> "" Then
                            depthnlocation(CInt(depthn.Text), mdepthx, mdepthy, ilength)
                            depthx.Text = CStr(mdepthx)
                            depthy.Text = CStr(mdepthy)
                        Else

                            depthxylocation(size_xarray, size_yarray, CDbl(depthx.Text), CDbl(depthy.Text), ilength)
                        End If
                        Refresh()
                        'adjust iteration number based on run type
                        If iterations < 1 Then iterations = 1
                        If Me.newfeedoption.Checked Then
                            iterations += 1
                            Me.replacefeedrates(startingFeedRate)
                        End If
                        If Me.runAsIs.Checked Then
                            iterations = 1
                        End If
                        If Me.depthstop.Checked Then
                            iterations = 1
                        End If
                        Me.iterationnumber.Text = iterations
                        'start iterations
                        For itercount = 1 To iterations

                            curdepth.Text = CStr(0)
                            r = 1
                            depthok = True
                            clipfrflag = False
                            'accelcheck(machine.maxacceln, machine.maxaccelt)
                            mini = minfeedratei(ilength - 1)

                            maxi = maxfeedratei(ilength - 1)
                            maxdfi = maxdeltafeedratei(ilength - 1)
                            maxfeedrate.Text = "F" & nc(maxi).f & "  at N" & nc(maxi).n
                            minFeedrate.Text = "F" & nc(mini).f & "  at N" & nc(mini).n
                            If maxdfi = 0 Then
                                maxdfeedrate.Text = "CONSTANT F"
                            Else
                                maxdfeedrate.Text = "F" & nc(maxdfi - 1).f & "  at N" & nc(maxdfi - 1).n & ControlChars.CrLf & "F" & nc(maxdfi).f & "  at N" & nc(maxdfi).n

                            End If


                            For i = 0 To size_xarray
                                For j = 0 To size_yarray
                                    surface(i, j) = start_surface(i, j)
                                    tempsurface(i, j) = 0
                                Next j
                            Next i
                            'End If

                            If itercount > 1 Then

                                fillarrays(ilength)
                            End If
                            Dim time As Double = runs * timetomachine()
                            If time >= 60 Then

                                txt_timetomachine.Text = Math.Floor(time / 60) & " hrs " & Math.Round(time Mod 60, 1) & " mins"
                            Else

                                txt_timetomachine.Text = Math.Round(time, 2) & " mins"
                            End If



                            Do While r <= runs And depthok

                                currun.Text = CStr(r)
                                curiter.Text = CStr(itercount)
                                curmrr.Text = CStr(depth_per_run)
                                'run model
                                model_run_success = subtract_surface(r)
                                If Not model_run_success Then Throw New Exception("Error during surface subtraction")
                                ProgressBar1.Value = r

                                curdepth.Text = CStr(avedepth(CDbl(depthx.Text), CDbl(depthy.Text), 2))
                                depth_display(r) = avedepth(CDbl(depthx.Text), CDbl(depthy.Text), 2)

                                If depthstop.Checked Then
                                    depthok = depthmonitor(CDbl(curdepth.Text))
                                    If depthok = False Then
                                        MessageBox.Show("Reached Target depth at run: " & r)
                                    End If
                                End If

                                If mrradjust.Checked Then
                                    depthok = depthmonitor(CDbl(curdepth.Text))
                                    If depthok = False And r = 1 Then
                                        MessageBox.Show("Reached Target depth at run: " & r)
                                        Exit For
                                    End If
                                    depthadjust(r, depth_per_run, newmrr)
                                    curmrr.Text = CStr(depth_per_run)
                                End If

                                Refresh()
                                r += 1
                                If depth_per_run = 0 Then
                                    'If CDbl(curmrr.Text) = 0 Then
                                    model_run_success = False
                                    Throw New Exception("MRR=0 during MRR adjust")
                                End If

                            Loop

                            If model_run_success Then
                                Dim newfeedok As Boolean = newfeedout(inputsurfacetype, newfeedoption.Checked)
                                If Not newfeedok Then
                                    Throw New Exception("Error during new feedrate calc.")
                                End If
                                If newfeedoption.Checked And itercount < iterations Then
                                    Dim newf(ilength) As Double
                                    For i = 0 To ilength
                                        newf(i) = Math.Round(nc(i).newf, 2)
                                    Next

                                    replacefeedrates(newf)
                                    Refresh()
                                    For i = 1 To ilength
                                        nc(i).f = Math.Round(nc(i).newf, 2)
                                    Next

                                End If
                                If newMiOption.Checked And itercount < iterations Then
                                    adjustMiArray()
                                End If
                            Else
                                Throw New Exception("Unknown Error")
                            End If
                            If clipfrflag Then
                                Me.Label11.Text = "Clipped Max F"

                            Else
                                Me.Label11.Text = "Max F"
                            End If

                        Next itercount
                        If newMiOption.Checked Then surfacefile.filesave("X,Y,MI", miCsvFilename, mi_surface, outputmesh, mesh_size)
                        If mipref Then dxfoutput.dxfsave(miFileName, mi_surface, outputmesh, mesh_size, ccomp, pathmin_x, pathmin_y)

                        'run one more time with new feedrates 
                        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Cross

                        panactive = False
                        zoomactive = False
                        xsectactive = False
                        crossactive = True
                        Me.pan.BackColor = SystemColors.Control
                        Me.zoom.BackColor = SystemColors.Control
                        Me.xsection.BackColor = SystemColors.Control
                        Me.crossh.BackColor = SystemColors.ActiveCaption
                        pan.Enabled = True
                        zoom.Enabled = True
                        zoomext.Enabled = True
                        crossh.Enabled = True
                        Me.crossh.BackColor = SystemColors.ActiveCaption
                        Me.ctxdepthmap.Checked = True
                        depthmap = True
                        frmap = False
                        updatelegend()
                        PictureBox1.Enabled = True
                        xsection.Enabled = True
                        PictureBox2.Enabled = True
                        calczoomexts()
                        refreshpicture(zoomextents)
                        ProgressBar1.Value = 0




                    End If
                    If model_run_success Then
                        finishtime = Now
                        elapsedtime = finishtime.Subtract(starttime)
                        runmodelstart = False
                        Dim elapsedSeconds As Integer = elapsedtime.Seconds + (60 * elapsedtime.Minutes) + (3600 * elapsedtime.Hours)
                        If elapsedSeconds > 60 Then
                            MessageBox.Show("Model Run Time:" & elapsedtime.ToString)
                        End If
                        refreshpanel(1, "Model Run Complete")
                    Else
                        runmodelstart = False
                        refreshpanel(1, "Model Run Aborted")
                    End If

                Else
                    runmodelstart = False
                    refreshpanel(1, "-")
                End If

            Catch ex As OutOfMemoryException
                ProgressBar1.Value = 0
                refreshpanel(1, "Model Memory Error")
                MessageBox.Show(ex.Message.ToString() & "sub:modelrun")
                runmodelstart = False
                'emptyarrays()
                disablepicture()
            Catch ex As OverflowException
                ProgressBar1.Value = 0
                refreshpanel(1, "Divide by zero Error")
                MessageBox.Show(ex.Message.ToString() & "sub:modelrun")
                runmodelstart = False
                'emptyarrays()
                disablepicture()
            Catch ex As Exception
                ProgressBar1.Value = 0
                refreshpanel(1, "Model Run Error")
                MessageBox.Show(ex.Message.ToString() & "sub:modelrun")
                runmodelstart = False
                'emptyarrays()
                disablepicture()
            End Try

        End Sub
        Sub disablepicture()
            clearpicturebox1()
            clearpicturebox2()
            pan.Enabled = False
            zoom.Enabled = False
            zoomext.Enabled = False
            crossh.Enabled = False
            xsection.Enabled = True

            panactive = False
            zoomactive = False
            xsectactive = False
            crossactive = False
            Me.pan.BackColor = SystemColors.Control
            Me.zoom.BackColor = SystemColors.Control
            Me.xsection.BackColor = SystemColors.Control
            Me.crossh.BackColor = SystemColors.Control

            Me.ctxdepthmap.Checked = True
            PictureBox1.Enabled = False
            PictureBox2.Enabled = False
        End Sub

        Private Sub Runmodel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Runmodel.Click
            Try
                model_run_success = False
                If Not runmodelstart And parameters_loaded Then
                    starttime = DateTime.Now
                    stopmodel.Enabled = True

                    thd = New Thread(AddressOf modelrun)
                    thd.Name = "modelthread"
                    thd.Start()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:runmodel_click")
            End Try


        End Sub 'run model click
        Private Sub emptyarrays()
            If surfaceOK Then
                Erase surface
                Erase tempsurface
                surfaceOK = False
            End If
            If startSurfaceOK Then
                Erase start_surface
                startSurfaceOK = False
            End If
            If targetSurfaceOK Then
                Erase target_surface
                targetSurfaceOK = False
            End If
            If miSurfaceOK Then
                Erase mi_surface
                miSurfaceOK = False
            End If
            If maskSurfaceOK Then
                Erase maskSurface
                maskSurfaceOK = False
            End If
        End Sub
        Private Sub stopmodel_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopmodel.Click
            'stop model run
            'aborts thread created by runmodel_click
            Try
                If runmodelstart Then
                    thd.Abort()
                    thd.Join()

                    Runmodel.Enabled = True
                    ProgressBar1.Value = 0
                    refreshpanel(1, "Model Run Aborted")
                    ProgressBar1.Refresh()
                    runmodelstart = False
                    model_run_success = False
                    'emptyarrays()
                    disablepicture()
                    emptyarrays()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:stopmodel_click")

            End Try

        End Sub 'stopmodel

        Private Sub dxf_to_target_surface(ByRef targetSurfaceOK As Boolean, ByVal regionpoint() As mdmodel.ddepthpoint, _
                                          ByRef tempsurface(,) As Double)
            Dim a, b, c, d, i, j, k, ta, tb As Integer
            Dim defval As Double = -1 * Math.Abs(nom_depth)
            ReDim rectregion(regioncount)
            'maps starting or target surface 
            'using dxf regions as inputs
            'dxf regions are rectangles drawn at the target height 
            Try
                ta = tempsurface.GetUpperBound(0)
                tb = tempsurface.GetUpperBound(1)
                'clear array
                For j = 0 To tb
                    For i = 0 To ta
                        tempsurface(i, j) = defval
                    Next i
                Next j
                'set region values
                For i = 0 To regioncount
                    rectregion(i).min_x = 999999
                    rectregion(i).max_x = -999999
                    rectregion(i).min_y = 999999
                    rectregion(i).max_y = -999999
                Next i
                'search for region boundaries
                For j = 0 To regioncount
                    For i = j * 4 To (j * 4) + 3
                        If regionpoint(i).x1 > rectregion(j).max_x Then rectregion(j).max_x = regionpoint(i).x1
                        If regionpoint(i).x2 > rectregion(j).max_x Then rectregion(j).max_x = regionpoint(i).x2
                        If regionpoint(i).y1 > rectregion(j).max_y Then rectregion(j).max_y = regionpoint(i).y1
                        If regionpoint(i).y2 > rectregion(j).max_y Then rectregion(j).max_y = regionpoint(i).y2
                        If regionpoint(i).x1 < rectregion(j).min_x Then rectregion(j).min_x = regionpoint(i).x1
                        If regionpoint(i).x2 < rectregion(j).min_x Then rectregion(j).min_x = regionpoint(i).x2
                        If regionpoint(i).y1 < rectregion(j).min_y Then rectregion(j).min_y = regionpoint(i).y1
                        If regionpoint(i).y2 < rectregion(j).min_y Then rectregion(j).min_y = regionpoint(i).y2
                        rectregion(j).z = regionpoint(i).z1

                    Next i
                Next j
                'set target surface to depth values
                For i = 0 To regioncount
                    a = getxindex(rectregion(i).min_x, mesh_size, ccomp, pathmin_x)
                    b = getxindex(rectregion(i).max_x, mesh_size, ccomp, pathmin_x)
                    c = getyindex(rectregion(i).min_y, mesh_size, ccomp, pathmin_y)
                    d = getyindex(rectregion(i).max_y, mesh_size, ccomp, pathmin_y)
                    If a < 0 Then a = 0
                    If b < 0 Then b = 0
                    If c < 0 Then c = 0
                    If d < 0 Then d = 0
                    If a > ta Then a = ta
                    If b > ta Then b = ta
                    If c > tb Then c = tb
                    If d > tb Then d = tb
                    For j = a To b
                        For k = c To d
                            tempsurface(j, k) = rectregion(i).z
                        Next k
                    Next j

                Next i
                targetSurfaceOK = True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:dxf_to_target_surface")
                targetSurfaceOK = False
            End Try

        End Sub 'dxf_to_target_surface
        Private Sub dxf_to_target_surface(ByRef targetSurfaceOK As Boolean, ByVal regionpoint() As mdmodel.ddepthpoint, _
                                          ByRef tempsurface(,) As Single)
            Dim a, b, c, d, i, j, k, ta, tb As Integer
            Dim defval As Double = -1 * Math.Abs(nom_depth)
            ReDim rectregion(regioncount)
            'maps starting or target surface 
            'using dxf regions as inputs
            'dxf regions are rectangles drawn at the target height 
            Try
                ta = tempsurface.GetUpperBound(0)
                tb = tempsurface.GetUpperBound(1)
                'clear array
                For j = 0 To tb
                    For i = 0 To ta
                        tempsurface(i, j) = defval
                    Next i
                Next j
                'set region values
                For i = 0 To regioncount
                    rectregion(i).min_x = 999999
                    rectregion(i).max_x = -999999
                    rectregion(i).min_y = 999999
                    rectregion(i).max_y = -999999
                Next i
                'search for region boundaries
                For j = 0 To regioncount
                    For i = j * 4 To (j * 4) + 3
                        If regionpoint(i).x1 > rectregion(j).max_x Then rectregion(j).max_x = regionpoint(i).x1
                        If regionpoint(i).x2 > rectregion(j).max_x Then rectregion(j).max_x = regionpoint(i).x2
                        If regionpoint(i).y1 > rectregion(j).max_y Then rectregion(j).max_y = regionpoint(i).y1
                        If regionpoint(i).y2 > rectregion(j).max_y Then rectregion(j).max_y = regionpoint(i).y2
                        If regionpoint(i).x1 < rectregion(j).min_x Then rectregion(j).min_x = regionpoint(i).x1
                        If regionpoint(i).x2 < rectregion(j).min_x Then rectregion(j).min_x = regionpoint(i).x2
                        If regionpoint(i).y1 < rectregion(j).min_y Then rectregion(j).min_y = regionpoint(i).y1
                        If regionpoint(i).y2 < rectregion(j).min_y Then rectregion(j).min_y = regionpoint(i).y2
                        rectregion(j).z = regionpoint(i).z1

                    Next i
                Next j
                'set target surface to depth values
                For i = 0 To regioncount
                    a = getxindex(rectregion(i).min_x, mesh_size, ccomp, pathmin_x)
                    b = getxindex(rectregion(i).max_x, mesh_size, ccomp, pathmin_x)
                    c = getyindex(rectregion(i).min_y, mesh_size, ccomp, pathmin_y)
                    d = getyindex(rectregion(i).max_y, mesh_size, ccomp, pathmin_y)
                    If a < 0 Then a = 0
                    If b < 0 Then b = 0
                    If c < 0 Then c = 0
                    If d < 0 Then d = 0
                    If a > ta Then a = ta
                    If b > ta Then b = ta
                    If c > tb Then c = tb
                    If d > tb Then d = tb
                    For j = a To b
                        For k = c To d
                            tempsurface(j, k) = rectregion(i).z
                        Next k
                    Next j

                Next i
                targetSurfaceOK = True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:dxf_to_target_surface")
                targetSurfaceOK = False
            End Try

        End Sub 'dxf_to_target_surface
        Private Sub interpolate2dSurface(ByRef localTargetSurfaceOK As Boolean, ByVal input As surfacetype, _
                                         ByVal localArrayExtents As mdmodel.dArrayExtents, ByRef outputSurface(,) As Integer, ByVal inputSurface(,) As Integer)
            'integer version
            Dim i, j, sr, sc As Integer
            Dim xm, ym, tempz As Double
            Dim tempsc, test As Integer

            'maps input surface array to output surface array
            Try
                If input = mdmodel.surfacetype.csvpoints Or input = mdmodel.surfacetype.dxfpoints Then
                    For j = 0 To outputSurface.GetUpperBound(1)
                        For i = 0 To outputSurface.GetUpperBound(0)
                            xm = getxlocation(i, mesh_size, ccomp, pathmin_x)
                            ym = getylocation(j, mesh_size, ccomp, pathmin_y)

                            findsubblock(xm, ym, localArrayExtents, sr, sc)


                            If sr < 0 And sc < 0 Then
                                outputSurface(i, j) = inputSurface(0, 0)
                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc < 0 Then
                                sc = 0
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.xmeshsize))
                                outputSurface(i, j) = tx(ym, inputSurface(sc, sr), inputSurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc < 0 Then
                                sr = sr - 1
                                sc = 0
                                outputSurface(i, j) = inputSurface(sc, sr)

                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr = localArrayExtents.rows Then
                                sr = sr - 1
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputSurface(i, j) = tx(xm, inputSurface(sc, sr), inputSurface(sc + 1, sr), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc = localArrayExtents.columns Then
                                sr = sr - 1
                                sc = sc - 1
                                outputSurface(i, j) = inputSurface(localArrayExtents.columns, localArrayExtents.rows)

                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc = localArrayExtents.columns Then
                                sc = sc - 1
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                                outputSurface(i, j) = tx(ym, inputSurface(sc, sr), inputSurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sc = localArrayExtents.columns And sr < 0 Then
                                sc = sc - 1
                                sr = 0
                                outputSurface(i, j) = inputSurface(sc, sr)
                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr < 0 Then
                                sr = 0
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputSurface(i, j) = tx(xm, inputSurface(sc, sr), inputSurface(sc + 1, sr), localArrayExtents.xmeshsize)
                            Else
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                                outputSurface(i, j) = Math.Round(txy(sr, sc, inputSurface(sc, sr), inputSurface(sc, sr + 1), _
                                                                 inputSurface(sc + 1, sr + 1), inputSurface(sc + 1, sr), _
                                                                 xm, ym, localArrayExtents.xmeshsize, localArrayExtents.ymeshsize), 0)
                            End If

                        Next i
                    Next j
                    localTargetSurfaceOK = True
                Else
                    localTargetSurfaceOK = False
                End If



            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " Sub interpolate2dSurface integer")
                localTargetSurfaceOK = False
            End Try
        End Sub 'interpolate2dSurface integer
        Private Sub interpolate2dSurface(ByRef localtargetSurfaceOK As Boolean, ByVal input As surfacetype, _
                                         ByVal localArrayExtents As mdmodel.dArrayExtents, ByRef outputsurface(,) As Double, ByVal inputsurface(,) As Double)
            'double precision version
            Dim i, j, sr, sc As Integer
            Dim xm, ym, tempz As Double
            Dim tempsc As Integer

            'maps input surface array to output surface array
            'uses linear interpolation to calc mesh values 
            'handles 1 or 2D csv points, 2d dxfpoints, and 1d dxf profile
            Try
                Debug.WriteLine(inputsurface.GetUpperBound(0) & "|" & inputsurface.GetUpperBound(1))
                Debug.WriteLine(localArrayExtents.columns & "|" & localArrayExtents.rows)
                If input = surfacetype.dxfpoints Or input = surfacetype.csvpoints Then
                    For j = 0 To outputsurface.GetUpperBound(1)
                        For i = 0 To outputsurface.GetUpperBound(0)
                            xm = getxlocation(i, mesh_size, ccomp, pathmin_x)
                            ym = getylocation(j, mesh_size, ccomp, pathmin_y)

                            findsubblock(xm, ym, localArrayExtents, sr, sc)


                            If sr < 0 And sc < 0 Then
                                outputsurface(i, j) = inputsurface(0, 0)
                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc < 0 Then
                                sc = 0
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(ym, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc < 0 Then
                                sc = 0
                                outputsurface(i, j) = inputsurface(sc, sr)

                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr = localArrayExtents.rows Then
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc = localArrayExtents.columns Then
                                outputsurface(i, j) = inputsurface(localArrayExtents.columns, localArrayExtents.rows)

                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc = localArrayExtents.columns Then
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                                outputsurface(i, j) = tx(ym, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sc = localArrayExtents.columns And sr < 0 Then
                                sr = 0
                                outputsurface(i, j) = inputsurface(sc, sr)
                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr < 0 Then
                                sr = 0
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.xmeshsize)
                            Else
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))

                                outputsurface(i, j) = txy(sr, sc, inputsurface(sc, sr), inputsurface(sc, sr + 1), _
                                              inputsurface(sc + 1, sr + 1), inputsurface(sc + 1, sr), _
                                               xm, ym, localArrayExtents.xmeshsize, localArrayExtents.ymeshsize)
                            End If
                        Next
                    Next
                ElseIf input = surfacetype.xprofile Then
                    For i = 0 To outputsurface.GetUpperBound(0)
                        xm = getxlocation(i, mesh_size, ccomp, pathmin_x)
                        findsubblock(xm, 0, localArrayExtents, sr, sc)

                        If sc < 0 Then
                            tempsc = 0
                            tempz = inputsurface(0, sr)
                        ElseIf sc >= localArrayExtents.columns - 1 Then
                            tempsc = localArrayExtents.columns - 1
                            tempz = inputsurface(localArrayExtents.columns - 1, sr)
                        Else
                            xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                            tempz = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.xmeshsize)

                        End If

                        sc = tempsc
                        For j = 0 To outputsurface.GetUpperBound(1)
                            outputsurface(i, j) = tempz
                        Next
                    Next

                ElseIf input = surfacetype.yprofile Then

                    For j = 0 To outputsurface.GetUpperBound(1)
                        ym = getylocation(j, mesh_size, ccomp, pathmin_y)
                        findsubblock(0, ym, localArrayExtents, sr, sc)

                        If sr < 0 Then
                            tempz = ttargetsurface(sc, 0)
                        ElseIf sr >= localArrayExtents.rows - 1 Then
                            tempz = ttargetsurface(sc, localArrayExtents.rows - 1)

                        Else
                            xm = xm - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                            tempz = tx(xm, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                        End If


                        For i = 0 To outputsurface.GetUpperBound(0)
                            outputsurface(i, j) = tempz
                        Next
                    Next
                End If

                localtargetSurfaceOK = True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " sub:interpolate2dSurface double")

                localtargetSurfaceOK = False
            End Try

        End Sub 'interpolate2dSurface double
        Private Sub interpolate2dSurface(ByRef localtargetSurfaceOK As Boolean, ByVal input As surfacetype, _
                                       ByVal localArrayExtents As mdmodel.dArrayExtents, ByRef outputsurface(,) As Single, ByVal inputsurface(,) As Single)
            'double precision version
            Dim i, j, sr, sc As Integer
            Dim xm, ym, tempz As Double
            Dim tempsc As Integer

            'maps input surface array to output surface array
            'uses linear interpolation to calc mesh values 
            'handles 1 or 2D csv points, 2d dxfpoints, and 1d dxf profile
            Try
                Debug.WriteLine(inputsurface.GetUpperBound(0) & "|" & inputsurface.GetUpperBound(1))
                Debug.WriteLine(localArrayExtents.columns & "|" & localArrayExtents.rows)
                If input = surfacetype.dxfpoints Or input = surfacetype.csvpoints Then
                    For j = 0 To outputsurface.GetUpperBound(1)
                        For i = 0 To outputsurface.GetUpperBound(0)
                            xm = getxlocation(i, mesh_size, ccomp, pathmin_x)
                            ym = getylocation(j, mesh_size, ccomp, pathmin_y)

                            findsubblock(xm, ym, localArrayExtents, sr, sc)


                            If sr < 0 And sc < 0 Then
                                outputsurface(i, j) = inputsurface(0, 0)
                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc < 0 Then
                                sc = 0
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(ym, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc < 0 Then
                                sc = 0
                                outputsurface(i, j) = inputsurface(sc, sr)

                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr = localArrayExtents.rows Then
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.ymeshsize)

                            ElseIf sr = localArrayExtents.rows And sc = localArrayExtents.columns Then
                                outputsurface(i, j) = inputsurface(localArrayExtents.columns, localArrayExtents.rows)

                            ElseIf sr >= 0 And sr < localArrayExtents.rows And sc = localArrayExtents.columns Then
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                                outputsurface(i, j) = tx(ym, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                            ElseIf sc = localArrayExtents.columns And sr < 0 Then
                                sr = 0
                                outputsurface(i, j) = inputsurface(sc, sr)
                            ElseIf sc >= 0 And sc < localArrayExtents.columns And sr < 0 Then
                                sr = 0
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                outputsurface(i, j) = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.xmeshsize)
                            Else
                                xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                                ym = ym - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))

                                outputsurface(i, j) = txy(sr, sc, inputsurface(sc, sr), inputsurface(sc, sr + 1), _
                                              inputsurface(sc + 1, sr + 1), inputsurface(sc + 1, sr), _
                                               xm, ym, localArrayExtents.xmeshsize, localArrayExtents.ymeshsize)
                            End If
                        Next
                    Next
                ElseIf input = surfacetype.xprofile Then
                    For i = 0 To outputsurface.GetUpperBound(0)
                        xm = getxlocation(i, mesh_size, ccomp, pathmin_x)
                        findsubblock(xm, 0, localArrayExtents, sr, sc)

                        If sc < 0 Then
                            tempsc = 0
                            tempz = inputsurface(0, sr)
                        ElseIf sc >= localArrayExtents.columns - 1 Then
                            tempsc = localArrayExtents.columns - 1
                            tempz = inputsurface(localArrayExtents.columns - 1, sr)
                        Else
                            xm = xm - (localArrayExtents.min_x + (sc * localArrayExtents.xmeshsize))
                            tempz = tx(xm, inputsurface(sc, sr), inputsurface(sc + 1, sr), localArrayExtents.xmeshsize)

                        End If

                        sc = tempsc
                        For j = 0 To outputsurface.GetUpperBound(1)
                            outputsurface(i, j) = tempz
                        Next
                    Next

                ElseIf input = surfacetype.yprofile Then

                    For j = 0 To outputsurface.GetUpperBound(1)
                        ym = getylocation(j, mesh_size, ccomp, pathmin_y)
                        findsubblock(0, ym, localArrayExtents, sr, sc)

                        If sr < 0 Then
                            tempz = ttargetsurface(sc, 0)
                        ElseIf sr >= localArrayExtents.rows - 1 Then
                            tempz = ttargetsurface(sc, localArrayExtents.rows - 1)

                        Else
                            xm = xm - (localArrayExtents.min_y + (sr * localArrayExtents.ymeshsize))
                            tempz = tx(xm, inputsurface(sc, sr), inputsurface(sc, sr + 1), localArrayExtents.ymeshsize)

                        End If


                        For i = 0 To outputsurface.GetUpperBound(0)
                            outputsurface(i, j) = tempz
                        Next
                    Next
                End If

                localtargetSurfaceOK = True
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " sub:interpolate2dSurface double")

                localtargetSurfaceOK = False
            End Try

        End Sub 'interpolate2dSurface Single

        Private Sub findsubblock(ByVal x As Double, ByVal y As Double, ByVal dtarget As mdmodel.dArrayExtents, _
                        ByRef r As Integer, ByRef c As Integer)
            Dim i, j As Integer
            Dim xtest, ytest, xtestp, ytestp As Double
            c = -1
            r = -1
            Try
                If x <= dtarget.min_x Then
                    c = -1

                ElseIf x > dtarget.max_x Then
                    c = dtarget.columns
                Else
                    'scan across columns to find column where x value falls
                    For i = 0 To dtarget.columns - 1
                        xtest = (dtarget.xmeshsize * i) + dtarget.min_x
                        xtestp = (dtarget.xmeshsize * (1 + i)) + dtarget.min_x
                        If x >= xtest And x < xtestp Then
                            c = i
                            Exit For
                        End If
                    Next i
                End If
                If y <= dtarget.min_y Then
                    r = -1

                ElseIf y > dtarget.max_y Then
                    r = dtarget.rows
                Else
                    'scan across rows to find row where Y value falls
                    For i = 0 To dtarget.rows - 1
                        ytest = (dtarget.ymeshsize * i) + dtarget.min_y
                        ytestp = (dtarget.ymeshsize * (1 + i)) + dtarget.min_y
                        If y >= ytest And y < ytestp Then
                            r = i
                            Exit For
                        End If
                    Next i
                End If

                'returns row 'r' and column 'c' of x, y value
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " sub:findsubblock")
            End Try
        End Sub 'findsubblock
        Private Function txy(ByVal row As Integer, ByVal column As Integer, ByVal trc As Double, ByVal trpc As Double, ByVal trpcp As Double, _
                             ByVal trcp As Double, ByVal x As Double, _
                             ByVal y As Double, ByVal xms As Double, ByVal yms As Double) As Double
            'linear interpolation
            'input sub-block trc,tr'c,tr'c',trc'
            'output txy 
            'takes row and column values from findsubblock
            Dim trx, trpx As Double
            Try
                trx = x * ((trcp - trc) / xms) + trc
                trpx = x * ((trpcp - trpc) / xms) + trpc
                txy = y * ((trpx - trx) / yms) + trx

            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " function: txy")
            End Try
        End Function 'txy
        Private Function tx(ByVal x As Double, ByVal tc As Double, ByVal tcp As Double, ByVal xms As Double) As Double
            'linear interpolation
            'tcp , tc ar input z values 
            'xms is x distance 
            Try
                tx = x * ((tcp - tc) / xms) + tc
            Catch ex As Exception
                Debug.WriteLine(ex.Message.ToString & " function: tx")
            End Try
        End Function
        Function isnumber(ByVal testString As String) As Boolean
            Dim i As Integer = 0
            Dim testnumber As String
            Dim test As Boolean = False

            Do While i <= 9
                testnumber = CStr(i)
                test = testString.Equals(testString, testnumber)
                If test Then
                    Return test
                    Exit Do
                End If
                i += 1
            Loop

        End Function


        Sub replacefeedrates(ByVal replacef As Double)

            Dim i, j, jmax, imax As Integer
            Dim ncline, newnclines(), newncline As String
            Try
                nclines = Richtextbox1.Lines 'load lines into array
                jmax = nc.GetUpperBound(0) ' get upper bound of movement section array
                imax = nclines.GetUpperBound(0) ' get upper bound of file array
                ReDim newnclines(imax) 'creat new array for rewritten nc lines
                j = 1 'index for beginning of movement section
                If replacef <= 0 Then Throw New Exception("Feedrates<=0 Not Allowed")
                For i = 0 To imax 'loop through file 


                    ncline = nclines(i) 'load line from array into string
                    ncline = ncline.Trim
                    If nc(j).fline = i Then

                        newncline = ncline.Remove(nc(j).fpos, (ncline.Length - nc(j).fpos))
                        newncline = (newncline.Insert(nc(j).fpos, CStr(Math.Round(replacef, 3))))
                        newncline = newncline
                        'Debug.WriteLine("i:" & i & " j:" & j & " newf: " & nc(j).newf & " f:" & nc(j).f)
                        If j < jmax Then
                            j = j + 1
                        End If
                    Else
                        newncline = ncline
                    End If
                    newnclines(i) = newncline
                Next
                rewritetextbox(newnclines)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "i:" & i & " j:" & j & " sub:replacefeedrates")
            End Try

        End Sub 'replacefeedrates

        Sub replacefeedrates(ByVal replacef() As Double)

            Dim i, j, jmax, imax As Integer
            Dim ncline, newnclines(), newncline As String
            Try
                nclines = Richtextbox1.Lines 'load lines into array
                jmax = nc.GetUpperBound(0) ' get upper bound of movement section array
                imax = nclines.GetUpperBound(0) ' get upper bound of file array
                ReDim newnclines(imax) 'creat new array for rewritten nc lines
                j = 1 'index for beginning of movement section

                For i = 0 To imax 'loop through file 
                    If replacef(j) <= 0 Then Throw New Exception("Feedrates<=0 Not Allowed")

                    ncline = nclines(i) 'load line from array into string
                    ncline = ncline.Trim
                    If nc(j).fline = i Then

                        newncline = ncline.Remove(nc(j).fpos, (ncline.Length - nc(j).fpos))
                        newncline = (newncline.Insert(nc(j).fpos, CStr(Math.Round(replacef(j), 3))))
                        newncline = newncline
                        'Debug.WriteLine("i:" & i & " j:" & j & " newf: " & nc(j).newf & " f:" & nc(j).f)
                        If j < jmax Then
                            j = j + 1
                        End If
                    Else
                        newncline = ncline
                    End If
                    newnclines(i) = newncline
                Next
                rewritetextbox(newnclines)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "i:" & i & " j:" & j & " sub:replacefeedrates")
            End Try

        End Sub 'replacefeedrates


        Sub load_info_file(ByVal filedir As String)
            Dim infofile As New infofile
            Dim openfiledialog1 As New OpenFileDialog
            ' infofile.loadheaders()
            openfiledialog1.InitialDirectory = filedir
            openfiledialog1.Filter = "Prm files (*.prm)|*.prm|Prx files (*.prx)|*.prx|All files (*.*)|*.*"
            openfiledialog1.FilterIndex = 2
            Try


                If openfiledialog1.ShowDialog() = DialogResult.OK Then
                    shortinfofilename = getshortfilename(openfiledialog1.FileName) 'openfiledialog1.FileName.Substring(openfiledialog1.FileName.LastIndexOf("\") + 1)
                    If openfiledialog1.FileName.EndsWith(".prx") Then
                        infofile.loadxmlinfofile(openfiledialog1.FileName)
                    ElseIf openfiledialog1.FileName.EndsWith(".prm") Then
                        infofile.loadfile(openfiledialog1.FileName)
                    End If

                    refreshpanel(4, shortinfofilename)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & " sub:mnuinfo_click load")

            End Try
            Me.depthx.Text = CStr(mdepthx)
            Me.depthy.Text = CStr(mdepthy)

            If parameters_loaded Then
                With parminfo
                    .testdepth.Visible = False
                    .testpasses.Visible = False
                    .testspeed.Visible = False
                    .Label11.Visible = False
                    .Label12.Visible = False
                    .Label13.Visible = False
                    .number_of_runs.Focus()
                    .Height = 478
                    parmpreload()
                    .Text = shortinfofilename
                    .ShowDialog()
                    .BringToFront()
                End With

            End If

            If parminfo.DialogResult = DialogResult.OK Then


                Me.runnumber.Text = CStr(numberruns)
                Me.curmrr.Text = CStr(depth_per_run)
                Me.Refresh()

            End If

        End Sub 'load_info_file

        Sub parmpreload()
            With parminfo
                .nomdepth.Text = CStr(nom_depth)
                .depthtolerance.Text = CStr(depth_tolerance)
                .matthickness.Text = CStr(material_thickness)
                .defjetdiam.Text = CStr(defccomp)
                .depthperrun.Text = CStr(depth_per_run)
                .nomfeedrate.Text = CStr(nom_feedrate)
                .number_of_runs.Text = CStr(numberruns)
                .thetacrit.Text = CStr(crit_angle_1)
                .mrr_type.Text = CStr(mrrtype)
                .armradius.Text = CStr(armradius)
                .Groovedir.SelectedItem = strgroovedir
                .cbo_abrasivetype.Text = CStr(str_abrasivetype)
                .cbo_jeweltype.Text = CStr(str_jeweltype)
                .cbo_machine.Text = CStr(str_machinename)
                .cbo_nozzletype.Text = CStr(str_nozzle)
                .cbo_pump.Text = CStr(str_pumpname)
                .txtabflow.Text = CStr(str_abrasiveflow)
                .txtjeweldiameter.Text = CStr(str_jeweldiameter)
                .txtmtdiameter.Text = CStr(str_mixingtdiameter)
                .txtsod.Text = CStr(str_sod)
                .txtmtlength.Text = CStr(str_mixingtlength)
                .txtpressure.Text = CStr(str_pressure)
                .txtmtdiameter.Text = CStr(str_mixingtdiameter)
                grvedir = CType(.Groovedir.SelectedIndex, WindowsApplication1.abmach.mdmodel.groovedirection)

            End With
        End Sub 'parmpreload


        Sub save_parm_file(ByVal filename As String)
            Try
                Dim savefiledialog1 As New SaveFileDialog
                Dim infofileout As New infofile
                savefiledialog1.Filter = "Prx files (*.prx)|*.prx|All files (*.*)|*.*"
                savefiledialog1.DefaultExt = "*.prx"
                savefiledialog1.AddExtension = True

                savefiledialog1.FileName = filename
                savefiledialog1.OverwritePrompt = False
                Dim result As DialogResult = savefiledialog1.ShowDialog(Me)
                If result = DialogResult.OK Then
                    infofileout.infosavexml(savefiledialog1.FileName)
                End If
                savefiledialog1.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:save_dxf_surf_file")
            End Try

        End Sub 'save_parm_file

        Sub save_dxf_surf_file(ByVal filename As String, ByVal surface1(,) As Double, _
                               ByVal surface2(,) As Double, ByVal outputmesh As Integer, _
                               ByVal meshsize As Double, ByVal pad As Double, ByVal min_x As Double, _
                               ByVal min_y As Double, ByVal blankvalue As Double, ByVal dtol As Double, _
                               ByVal dmax As Double)
            Try
                Dim savefiledialog1 As New SaveFileDialog
                Dim dxfoutput As New DXFfile
                savefiledialog1.Filter = "DXF Files(*.dxf)|*.dxf"
                savefiledialog1.DefaultExt = "*.dxf"
                savefiledialog1.AddExtension = True

                savefiledialog1.FileName = filename
                savefiledialog1.OverwritePrompt = False
                Dim result As DialogResult = savefiledialog1.ShowDialog(Me)
                If result = DialogResult.OK Then
                    dxfoutput.dxfsave(savefiledialog1.FileName, surface1, surface2, outputmesh, meshsize, pad, min_x, min_y, blankvalue, dtol, dmax)
                    'dxffilename = savefiledialog1.FileName
                End If
                savefiledialog1.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:save_dxf_surf_file")
            End Try

        End Sub 'save_dxf_surf_file
        Sub save_dxf_surf_file(ByVal filename As String, ByVal surface1(,) As Single, _
                            ByVal surface2(,) As Single, ByVal outputmesh As Integer, _
                            ByVal meshsize As Double, ByVal pad As Double, ByVal min_x As Double, _
                            ByVal min_y As Double, ByVal blankvalue As Double, ByVal dtol As Double, _
                            ByVal dmax As Double)
            Try
                Dim savefiledialog1 As New SaveFileDialog
                Dim dxfoutput As New DXFfile
                savefiledialog1.Filter = "DXF Files(*.dxf)|*.dxf"
                savefiledialog1.DefaultExt = "*.dxf"
                savefiledialog1.AddExtension = True

                savefiledialog1.FileName = filename
                savefiledialog1.OverwritePrompt = False
                Dim result As DialogResult = savefiledialog1.ShowDialog(Me)
                If result = DialogResult.OK Then
                    dxfoutput.dxfsave(savefiledialog1.FileName, surface1, surface2, outputmesh, meshsize, pad, min_x, min_y, blankvalue, dtol, dmax)
                    'dxffilename = savefiledialog1.FileName
                End If
                savefiledialog1.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub:save_dxf_surf_file")
            End Try

        End Sub 'save_dxf_surf_file

        Sub save_csv_surf_file(ByVal fileHeader As String, ByVal filename As String, _
        ByVal localSurface(,) As Double, ByVal localMeshstep As Integer, ByVal localMeshsize As Double)
            Try
                Dim savefiledialog2 As New SaveFileDialog
                Dim surfacefileout As New surfacefile

                savefiledialog2.Filter = "CSV Files(*.csv)|*.csv"
                savefiledialog2.DefaultExt = "*.csv"
                savefiledialog2.AddExtension = True
                savefiledialog2.FileName = filename
                savefiledialog2.OverwritePrompt = False

                saveFileDialog.Reset()
                Dim result As DialogResult = savefiledialog2.ShowDialog(Me)
                If result = DialogResult.OK Then
                    surfacefileout.filesave(fileHeader, savefiledialog2.FileName, localSurface, localMeshstep, localMeshsize)
                End If
                savefiledialog2.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub: save_csv_surf_file")
            End Try

        End Sub 'save_csv_surf_file
        Sub save_csv_surf_file(ByVal fileHeader As String, ByVal filename As String, _
             ByVal localSurface(,) As Single, ByVal localMeshstep As Integer, ByVal localMeshsize As Double)
            Try
                Dim savefiledialog2 As New SaveFileDialog
                Dim surfacefileout As New surfacefile

                savefiledialog2.Filter = "CSV Files(*.csv)|*.csv"
                savefiledialog2.DefaultExt = "*.csv"
                savefiledialog2.AddExtension = True
                savefiledialog2.FileName = filename
                savefiledialog2.OverwritePrompt = False

                saveFileDialog.Reset()
                Dim result As DialogResult = savefiledialog2.ShowDialog(Me)
                If result = DialogResult.OK Then
                    surfacefileout.filesave(fileHeader, savefiledialog2.FileName, localSurface, localMeshstep, localMeshsize)
                End If
                savefiledialog2.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString & "in sub: save_csv_surf_file")
            End Try

        End Sub 'save_csv_surf_file

        Private Sub mnuscanfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuscanfile.Click
            scanfile()
        End Sub


        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            Try
                Me.sbfrm1.Panels(0).Text = "Time:" & FormatDateTime(DateTime.Now, DateFormat.LongTime)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try

        End Sub

        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim prefs As New preferences
            prefs.loadpreferences()
            Me.runAsIs.Checked = True
            'Me.dxfoption.Checked = dxfpref
            'Me.surfoption.Checked = csvpref

        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub


        Private Sub mnuRenumberFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRenumberFile.Click

            Dim renumber As New RenumberForm
            renumber.ShowDialog()
            renumber.BringToFront()
            renumberFile(renumber.lineNumberStart, renumber.lineNumberIncrement)
        End Sub
        Public Sub renumberFile(ByVal startValue As Integer, ByVal increment As Integer)
            Dim i, j, jmax, imax, nIndex, nIndexStart, nIndexEnd, nValue, newN, lineLength As Integer
            Dim ncLine, newNcLines(), newNcLine, oldLineNumber, newLineNumber, ncLines(), testString As String
            Try
                ncLines = Richtextbox1.Lines 'load lines into array
                jmax = nc.GetUpperBound(0) ' get upper bound of movement section array
                imax = ncLines.GetUpperBound(0) ' get upper bound of file array
                ReDim newNcLines(imax) 'creat new array for rewritten nc lines   
                newN = startValue
                For i = 0 To imax
                    ncLine = ncLines(i)
                    If Not (ncLine Is Nothing) Then
                        newNcLine = ncLine
                        nIndexStart = -1
                        ncLine = ncLine.Trim
                        nIndexStart = ncLine.IndexOf("N")
                        lineLength = ncLine.Length
                        If nIndexStart < lineLength - 1 Then


                            testString = ncLine.Substring(nIndexStart + 1, 1)

                            If nIndexStart <> -1 And isnumber(testString) Then
                                nIndexEnd = ncLine.IndexOf(" ", nIndexStart + 1)
                                oldLineNumber = ncLine.Substring(nIndexStart, nIndexEnd - nIndexStart)
                                newLineNumber = "N" + CStr(newN)
                                newNcLine = ncLine.Replace(oldLineNumber, newLineNumber)
                                newN += increment
                            End If
                        End If
                    End If
                    newNcLines(i) = newNcLine
                Next
                rewritetextbox(newNcLines)
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString() & "sub:renumberFile")

            End Try

        End Sub

    End Class 'Form1
End Namespace 'abmach