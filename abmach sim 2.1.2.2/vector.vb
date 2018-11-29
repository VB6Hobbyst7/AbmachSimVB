Public Class vector

    Dim dx As Double
    Dim dy As Double
    Dim dz As Double
    Dim dmag As Double

    
    Property x() As Double
        Get
            Return dx
        End Get
        Set(ByVal Value As Double)
            dx = Value
        End Set
    End Property

    Property y() As Double
        Get
            Return dy
        End Get
        Set(ByVal Value As Double)
            dy = Value
        End Set
    End Property
    Property z() As Double
        Get
            Return dz
        End Get
        Set(ByVal Value As Double)
            dz = Value
        End Set
    End Property
    ReadOnly Property mag() As Double
        Get
            dmag = Math.Sqrt(dx ^ 2 + dy ^ 2 + dz ^ 2)
            Return dmag
        End Get
    End Property
    Public Sub New(x As Double, y As Double, z As Double)
        dx = x
        dy = y
        dz = z

    End Sub
    Public Sub New()
        dx = 0
        dy = 0
        dz = 0

    End Sub

    Function dot(ByVal v2 As vector) As Double
        'calc dot product of two vectors
        dot = (Me.dx * v2.dx) + (Me.dy * v2.dy) + (Me.dz * v2.dz)
        Return dot
    End Function 'dot product
    Function cross(ByVal v2 As vector) As vector
        Dim vcross As New vector
        'calc cross product of two vectors
        vcross.x = (Me.y * v2.z) - (Me.z * v2.y)
        vcross.y = (Me.z * v2.x) - (Me.x * v2.z)
        vcross.z = (Me.x * v2.y) - (Me.y * v2.x)
        Return vcross
    End Function 'cross product
End Class
