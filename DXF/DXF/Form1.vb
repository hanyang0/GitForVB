Imports dxflib
Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim doc As New DXFLibrary.Document()

        Dim tables As New DXFLibrary.Tables()

        doc.SetTables(tables)

        Dim layers As New DXFLibrary.Table("LAYER")

        tables.addTable(layers)

        Dim layerDoors As DXFLibrary.Layer

        layerDoors = New DXFLibrary.Layer("Doors", 30, "CONTINUOUS")

        layers.AddTableEntry(layerDoors)

        Dim cc As New DXFLibrary.Circle(5, 5, 0.1, "PartialHeightDoors")

        doc.add(cc)

        Dim line1 As New DXFLibrary.Line("Doors", 0, 0, 0, 10)

        doc.add(line1)

        Dim line2 As New DXFLibrary.Line("Doors", 0, 0, 10, 0)

        doc.add(line2)

        Dim line3 As New DXFLibrary.Line("Doors", 10, 10, 0, 10)

        doc.add(line3)

        Dim line4 As New DXFLibrary.Line("Doors", 10, 10, 10, 0)

        doc.add(line4)

        'Dim line5 As New DXFLibrary.Line3D("Doors", 2, 2, 0, 5, 5, 10)

        'doc.add(line5)

        Dim f1 As New IO.FileStream("test2.dxf", System.IO.FileMode.Create)

        DXFLibrary.Writer.Write(doc, f1)

        f1.Close()

    End Sub
End Class
