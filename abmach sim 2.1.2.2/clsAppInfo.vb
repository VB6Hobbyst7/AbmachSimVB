Imports SR = System.Reflection

Interface IApplicationSM
    ReadOnly Property Title() As String
    ReadOnly Property Description() As String
    ReadOnly Property Company() As String
    ReadOnly Property Product() As String
    ReadOnly Property Copyright() As String
    ReadOnly Property Trademark() As String
    ReadOnly Property Version() As String
End Interface
Public Class clsAppInfo
    Dim m_AssInfo As System.Reflection.Assembly

    Sub New()
        m_AssInfo = System.Reflection.Assembly.GetExecutingAssembly
    End Sub
    Public ReadOnly Property Company() As String
        Get
            Dim m_Company As SR.AssemblyCompanyAttribute
            m_Company = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyCompanyAttribute), False)(0)
            Return m_Company.Company.ToString
        End Get
    End Property
    Public ReadOnly Property Copyright() As String
        Get
            Dim m_Copyright As SR.AssemblyCopyrightAttribute
            m_Copyright = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyCopyrightAttribute), False)(0)
            Return m_Copyright.Copyright.ToCharArray
        End Get
    End Property
    Public ReadOnly Property Description() As String
        Get
            Dim m_Description As SR.AssemblyDescriptionAttribute
            m_Description = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyDescriptionAttribute), False)(0)
            Return m_Description.Description.ToString
        End Get
    End Property
    Public ReadOnly Property Product() As String
        Get
            Dim m_Product As SR.AssemblyProductAttribute
            m_Product = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyProductAttribute), False)(0)
            Return m_Product.Product.ToString
        End Get
    End Property
    Public ReadOnly Property Title() As String
        Get
            Dim m_Title As SR.AssemblyTitleAttribute
            m_Title = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyTitleAttribute), False)(0)
            Return m_Title.Title.ToString
        End Get
    End Property
    Public ReadOnly Property Trademark() As String
        Get
            Dim m_Trademark As SR.AssemblyTrademarkAttribute
            m_Trademark = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyTrademarkAttribute), False)(0)
            Return m_Trademark.Trademark.ToString
        End Get
    End Property
    Public ReadOnly Property Version() As String
        Get
            Dim m_Version As SR.AssemblyInformationalVersionAttribute
            m_Version = m_AssInfo.GetCustomAttributes(GetType(SR.AssemblyInformationalVersionAttribute), False)(0)
            Return m_Version.InformationalVersion.ToString
        End Get
    End Property
End Class
