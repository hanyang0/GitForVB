Class MainWindow
    Public Sub MainWindow()
        Dim students(2) As PageModel
        students(0) = New PageModel With {
            .ClassName = "高二三班",
        .Name = "张三",
        .Age = "18",
        .Sex = "男"
        }
        students(1) = New PageModel With {
            .ClassName = "高二三班",
        .Name = "李四",
        .Age = "19",
        .Sex = "女"
        }
        students(2) = New PageModel With {
            .ClassName = "高二三班",
        .Name = "王五",
        .Age = "20",
        .Sex = "男"
        }
        DataContext = students(2)


    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Call MainWindow()
    End Sub
End Class
Public Class PageModel
    Private _ClassName As String
    Private _Name As String
    Private _Age As String
    Private _Sex As String

    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property Age As String
        Get
            Return _Age
        End Get
        Set(value As String)
            _Age = value
        End Set
    End Property
    Public Property Sex As String
        Get
            Return _Sex
        End Get
        Set(value As String)
            _Sex = value
        End Set
    End Property

    Public Property ClassName As String
        Get
            Return _ClassName
        End Get
        Set(value As String)
            _ClassName = value
        End Set
    End Property
End Class

