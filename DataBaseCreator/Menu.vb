Imports System.Data.SqlClient
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common


Public Class Menu
    Dim Db As Database
    Dim srv As Server
    Private Sub TableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem.Click

    End Sub
    Private Sub DatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem.Click

    End Sub

    Private Sub CheckConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckConnectionToolStripMenuItem.Click
        Try
            srv = New Server("ESTEBAN\SQLEXPRESS")
            Label_Server.Text = "Connected to: ESTEBAN\SQLEXPRESS"
            MessageBox.Show("Connected to: ESTEBAN\SQLEXPRESS")
        Catch
            MessageBox.Show("Unable to connect")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DatabaseToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem2.Click
        MessageBox.Show("HOLa")
        Dim DBname = InputBox("New DataBase Name: ")
        Try
            srv = New Server("ESTEBAN\SQLEXPRESS")
            Db = New Database(srv, DBname)
            Db.Create()
            Label_DB.Text = "Using DB: " + DBname
            MessageBox.Show("Created DataBase " + DBname)
        Catch
            Try
                srv = New Server("(local)")
                Db = New Database(srv, DBname)
                Db.Create()
                Label_DB.Text = "Using DB: " + DBname
                MessageBox.Show("Created DataBase " + DBname)
            Catch
                MessageBox.Show("Error at creating DataBase: " + DBname)
            End Try

        End Try


    End Sub

    Private Sub TableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem1.Click

    End Sub

    Private Sub ArticuloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArticuloToolStripMenuItem.Click
        Try
            Dim tb_Productos As Table
            tb_Productos = New Table(Db, "Productos")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Productos, "IdProducto", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Productos.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Productos, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Productos.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Productos, "PrecioU", DataType.Money)
            col3.Nullable = False
            tb_Productos.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Productos, "Medida", DataType.VarChar(20))
            col4.Nullable = False
            tb_Productos.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Productos, "IdProveedor", DataType.Int)
            col5.Nullable = False
            tb_Productos.Columns.Add(col5)

            tb_Productos.Create()
            Dim query As String = "ALTER TABLE Productos ADD PRIMARY KEY (IdProducto)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Productos] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Productos")
        End Try
    End Sub

    Private Sub DatabaseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem1.Click
        Try
            Dim DBlist As New List(Of String)
            For Each DB As Database In srv.Databases
                DBlist.Add(DB.Name)
            Next
            Dim sdb As New SelectDB(DBlist)
            Dim str As String
            Dim dbNAme As String = ""
            ' Show testDialog as a modal dialog and determine if DialogResult = OK. 
            If sdb.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ' Read the contents of testDialog's TextBox.
                str = "You are using [" + sdb.Listbox_Databases.SelectedItem.ToString() + "] database."
                dbNAme = sdb.Listbox_Databases.SelectedItem.ToString()
            Else
                str = "Operation Cancelled"
            End If
            sdb.Dispose()
            Label_DB.Text = "Using DB: " + dbNAme
            MessageBox.Show(str)
            Db = srv.Databases(dbNAme)

        Catch

            MessageBox.Show("Check the connection first.")
        End Try
    End Sub

    Private Sub ProveedorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedorToolStripMenuItem.Click
        Try
            Dim tb_Proveedores As Table
            tb_Proveedores = New Table(Db, "Proveedores")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Proveedores, "IdProveedor", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Proveedores.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Proveedores, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Proveedores.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Proveedores, "Direccion", DataType.VarChar(50))
            col3.Nullable = True
            tb_Proveedores.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Proveedores, "Telefono", DataType.VarChar(15))
            col4.Nullable = True
            tb_Proveedores.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Proveedores, "Estado", DataType.VarChar(50))
            col5.Nullable = True
            tb_Proveedores.Columns.Add(col5)

            Dim col6 As Column
            col6 = New Column(tb_Proveedores, "Municipio", DataType.VarChar(50))
            col6.Nullable = True
            tb_Proveedores.Columns.Add(col6)




            tb_Proveedores.Create()

            Dim query As String = "ALTER TABLE Proveedores ADD PRIMARY KEY (IdProveedor)"
            Db.ExecuteWithResults(query)
            MessageBox.Show("Table [Proveedores] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Proveedores")
        End Try
    End Sub

    Private Sub SaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaldosToolStripMenuItem.Click
        Try
            Dim tb_Saldos As Table
            tb_Saldos = New Table(Db, "Saldos")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Saldos, "IdProducto", DataType.Int)
            col1.Nullable = False
            tb_Saldos.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Saldos, "IdProveedor", DataType.Int)
            col2.Nullable = False
            tb_Saldos.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Saldos, "SaldoInicioMes", DataType.Int)
            col3.Nullable = True
            tb_Saldos.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Saldos, "SaldoInicioDia", DataType.Int)
            col4.Nullable = True
            tb_Saldos.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Saldos, "SaldoProteccion", DataType.Int)
            col5.Nullable = True
            tb_Saldos.Columns.Add(col5)

            Dim col6 As Column
            col6 = New Column(tb_Saldos, "SaldoReorden", DataType.Int)
            col6.Nullable = True
            tb_Saldos.Columns.Add(col6)

            tb_Saldos.Create()
   
            MessageBox.Show("Table [Saldos] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Saldos")
        End Try
    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendedoresToolStripMenuItem.Click
        Try
            Dim tb_Empleados As Table
            tb_Empleados = New Table(Db, "Empleados")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Empleados, "IdEmpleado", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Empleados.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Empleados, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Empleados.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Empleados, "Direccion", DataType.VarChar(50))
            col3.Nullable = True
            tb_Empleados.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Empleados, "Telefono", DataType.VarChar(15))
            col4.Nullable = True
            tb_Empleados.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Empleados, "Correo", DataType.VarChar(50))
            col5.Nullable = True
            tb_Empleados.Columns.Add(col5)

            tb_Empleados.Create()

            Dim query As String = "ALTER TABLE Empleados ADD PRIMARY KEY (IdEmpleado)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Empleados] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Empleados")
        End Try
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Try
            Dim tb_Salidas As Table
            tb_Salidas = New Table(Db, "Salidas")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Salidas, "IdSalida", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Salidas.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Salidas, "IdProducto", DataType.Int)
            col2.Nullable = False
            tb_Salidas.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Salidas, "IdEmpleado", DataType.Int)
            col3.Nullable = False
            tb_Salidas.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Salidas, "Fecha", DataType.DateTime)
            col4.Nullable = False
            tb_Salidas.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Salidas, "NombreCliente", DataType.VarChar(50))
            col5.Nullable = True
            tb_Salidas.Columns.Add(col5)

            Dim col6 As Column
            col6 = New Column(tb_Salidas, "Cantidad", DataType.Int)
            col6.Nullable = False
            tb_Salidas.Columns.Add(col6)

            Dim col7 As Column
            col7 = New Column(tb_Salidas, "Descuento", DataType.Float)
            col7.Nullable = True

            Dim col8 As Column
            col8 = New Column(tb_Salidas, "Total", DataType.Float)
            col8.Nullable = True

            tb_Salidas.Create()

            Dim query As String = "ALTER TABLE Salidas ADD PRIMARY KEY (IdSalida)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Salidas] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Salidas")
        End Try
    End Sub

    Private Sub RelationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RelationToolStripMenuItem1.Click
       

    End Sub

    Private Sub ProductoProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoProveedoresToolStripMenuItem.Click
        Try
            Dim query1 As String = "ALTER TABLE Saldos ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Saldos ADD FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Saldos-Proveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Saldos-Proveedores]")
        End Try
       

    End Sub

    Private Sub ViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem1.Click

       
        
 
    End Sub

    Private Sub PrimaryKeysToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DatabaseToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DatabaseToolStripMenuItem3.Click
       

        Try
            Dim DBlist As New List(Of String)
            For Each DB As Database In srv.Databases
                DBlist.Add(DB.Name)
            Next
            Dim sdb As New SelectDB(DBlist)
            Dim str As String
            Dim dbName As String = ""
            ' Show testDialog as a modal dialog and determine if DialogResult = OK. 
            If sdb.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ' Read the contents of testDialog's TextBox.
                str = "Database [" + sdb.Listbox_Databases.SelectedItem.ToString() + "] was deleted successfuly"
                dbName = sdb.Listbox_Databases.SelectedItem.ToString()

            Else
                str = "Operation Cancelled"
            End If
            sdb.Dispose()
            Db = srv.Databases(dbName)
            srv.KillDatabase(Db.Name)
            MessageBox.Show(str)
            
        Catch
            MessageBox.Show("Unable to delete Database.")
        End Try

    End Sub

    Private Sub ProveedorSaldosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProveedorSaldosToolStripMenuItem.Click
        Try
            Dim query1 As String = "ALTER TABLE Salidas ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Salidas ADD FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Salidas-Empleados] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Salidas-Empleados]")
        End Try
    End Sub

    Private Sub CreateAllTablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAllTablesToolStripMenuItem.Click
        Try
            Dim tb_Productos As Table
            tb_Productos = New Table(Db, "Productos")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Productos, "IdProducto", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Productos.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Productos, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Productos.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Productos, "PrecioU", DataType.Money)
            col3.Nullable = False
            tb_Productos.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Productos, "Medida", DataType.VarChar(20))
            col4.Nullable = False
            tb_Productos.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Productos, "IdProveedor", DataType.Int)
            col5.Nullable = False
            tb_Productos.Columns.Add(col5)

            tb_Productos.Create()
            Dim query As String = "ALTER TABLE Productos ADD PRIMARY KEY (IdProducto)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Productos] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Productos")
        End Try

        Try
            Dim tb_Proveedores As Table
            tb_Proveedores = New Table(Db, "Proveedores")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Proveedores, "IdProveedor", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Proveedores.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Proveedores, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Proveedores.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Proveedores, "Direccion", DataType.VarChar(50))
            col3.Nullable = True
            tb_Proveedores.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Proveedores, "Telefono", DataType.VarChar(15))
            col4.Nullable = True
            tb_Proveedores.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Proveedores, "Estado", DataType.VarChar(50))
            col5.Nullable = True
            tb_Proveedores.Columns.Add(col5)

            Dim col6 As Column
            col6 = New Column(tb_Proveedores, "Municipio", DataType.VarChar(50))
            col6.Nullable = True
            tb_Proveedores.Columns.Add(col6)




            tb_Proveedores.Create()

            Dim query As String = "ALTER TABLE Proveedores ADD PRIMARY KEY (IdProveedor)"
            Db.ExecuteWithResults(query)
            MessageBox.Show("Table [Proveedores] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Proveedores")
        End Try

        Try
            Dim tb_Saldos As Table
            tb_Saldos = New Table(Db, "Saldos")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Saldos, "IdProducto", DataType.Int)
            col1.Nullable = False
            tb_Saldos.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Saldos, "IdProveedor", DataType.Int)
            col2.Nullable = False
            tb_Saldos.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Saldos, "SaldoInicioMes", DataType.Int)
            col3.Nullable = True
            tb_Saldos.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Saldos, "SaldoInicioDia", DataType.Int)
            col4.Nullable = True
            tb_Saldos.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Saldos, "SaldoProteccion", DataType.Int)
            col5.Nullable = True
            tb_Saldos.Columns.Add(col5)

            tb_Saldos.Create()

            MessageBox.Show("Table [Saldos] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Saldos")
        End Try
        Try
            Dim tb_Empleados As Table
            tb_Empleados = New Table(Db, "Empleados")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Empleados, "IdEmpleado", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Empleados.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Empleados, "Nombre", DataType.VarChar(50))
            col2.Nullable = False
            tb_Empleados.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Empleados, "Direccion", DataType.VarChar(50))
            col3.Nullable = True
            tb_Empleados.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Empleados, "Telefono", DataType.VarChar(15))
            col4.Nullable = True
            tb_Empleados.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Empleados, "Correo", DataType.VarChar(50))
            col5.Nullable = True
            tb_Empleados.Columns.Add(col5)

            tb_Empleados.Create()

            Dim query As String = "ALTER TABLE Empleados ADD PRIMARY KEY (IdEmpleado)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Empleados] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Empleados")
        End Try
        Try
            Dim tb_Salidas As Table
            tb_Salidas = New Table(Db, "Salidas")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Salidas, "IdSalida", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Salidas.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Salidas, "IdProducto", DataType.Int)
            col2.Nullable = False
            tb_Salidas.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Salidas, "IdEmpleado", DataType.Int)
            col3.Nullable = False
            tb_Salidas.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Salidas, "Fecha", DataType.DateTime)
            col4.Nullable = False
            tb_Salidas.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Salidas, "NombreCliente", DataType.VarChar(50))
            col5.Nullable = True
            tb_Salidas.Columns.Add(col5)

            Dim col6 As Column
            col6 = New Column(tb_Salidas, "Cantidad", DataType.Int)
            col6.Nullable = False

            Dim col7 As Column
            col7 = New Column(tb_Salidas, "Descuento", DataType.Float)
            col7.Nullable = True

            Dim col8 As Column
            col8 = New Column(tb_Salidas, "Total", DataType.Float)
            col8.Nullable = True

            tb_Salidas.Create()

            Dim query As String = "ALTER TABLE Salidas ADD PRIMARY KEY (IdSalida)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Salidas] created successfuly on DataBase " + Db.Name)
        Catch
            MessageBox.Show("Unable to create table: Salidas")
        End Try
    End Sub

    Private Sub CreateAllRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAllRelationsToolStripMenuItem.Click
        Try
            Dim query1 As String = "ALTER TABLE Saldos ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Saldos ADD FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Saldos-Proveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Saldos-Proveedores]")
        End Try

        Try
            Dim query1 As String = "ALTER TABLE Salidas ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Salidas ADD FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Salidas-Empleados] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Salidas-Empleados]")
        End Try

        Try
            Dim query1 As String = "ALTER TABLE Productos ADD FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor)"

            Db.ExecuteWithResults(query1)

            MessageBox.Show("Relation [Productos-Proveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Proveedores]")
        End Try

        Try
            Dim query1 As String = "ALTER TABLE Entradas ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Entradas ADD FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Salidas-Entradas] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Salidas-Entradas]")
        End Try

    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Try
            Dim query1 As String = "Create view VistaProductos As Select * From Productos"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaProductos] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaProductos]")
        End Try
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Try
            Dim query1 As String = "Create view VistaProveedores As Select * From Proveedores"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaProveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaProveedores]")
        End Try
    End Sub

    Private Sub SaldosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaldosToolStripMenuItem1.Click
        Try
            Dim query1 As String = "Create view VistaSaldos As Select * From Saldos"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaSaldos] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaSaldos]")
        End Try

    End Sub

    Private Sub VendedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VendedoresToolStripMenuItem1.Click
        Try
            Dim query1 As String = "Create view VistaEmpleados As Select * From Empleados"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaEmpleados] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaEmpleados]")
        End Try
    End Sub

    Private Sub VentasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem2.Click
        Try
            Dim query1 As String = "Create view VistaSalidas As Select * From Salidas"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaSalidas] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaSalidas]")
        End Try
    End Sub

    Private Sub CreateAllViewsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateAllViewsToolStripMenuItem.Click
        Try
            Dim query1 As String = "Create view VistaProductos As Select * From Productos"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaProductos] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaProductos]")
        End Try
        Try
            Dim query1 As String = "Create view VistaProveedores As Select * From Proveedores"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaProveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaProveedores]")
        End Try
        Try
            Dim query1 As String = "Create view VistaSaldos As Select * From Saldos"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaSaldos] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaSaldos]")
        End Try
        Try
            Dim query1 As String = "Create view VistaEmpleados As Select * From Empleados"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaEmpleados] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaEmpleados]")
        End Try
        Try
            Dim query1 As String = "Create view VistaSalidas As Select * From Salidas"
            Db.ExecuteWithResults(query1)
            MessageBox.Show("View [VistaSalidas] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create View [VistaSalidas]")
        End Try
    End Sub

    Private Sub TableToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TableToolStripMenuItem2.Click
        Try
            Dim Tablelist As New List(Of String)
            For Each TABLE As Table In Db.Tables
                Tablelist.Add(TABLE.Name)
            Next
            Dim sdb As New SelectDB(Tablelist)
            Dim str As String
            Dim TableName As String = ""
            ' Show testDialog as a modal dialog and determine if DialogResult = OK. 
            If sdb.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                ' Read the contents of testDialog's TextBox.
                str = "Table [" + sdb.Listbox_Databases.SelectedItem.ToString() + "] was deleted successfuly"
                TableName = sdb.Listbox_Databases.SelectedItem.ToString()

            Else
                str = "Operation Cancelled"
            End If
            sdb.Dispose()
            Db.Tables(TableName).Drop()
            MessageBox.Show(str)
        Catch
            MessageBox.Show("Unable to delete Table. Check the relations first")
        End Try
    End Sub

    Private Sub ProductosSaldosProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosSaldosProveedoresToolStripMenuItem.Click
        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Saldos")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Saldos-Proveedores] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Saldos-Proveedores]")
        End Try
       

    End Sub

    Private Sub ProductosVentasVendedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosVentasVendedoresToolStripMenuItem.Click
        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Salidas")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Salidas-Empleados] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Salidas-Empleados]")
        End Try
    End Sub

    Private Sub DeleteAllRelationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllRelationsToolStripMenuItem.Click
        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Saldos")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Saldos-Proveedores] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Saldos-Proveedores]")
        End Try
        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Salidas")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Salidas-Empleados] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Salidas-Empleados]")
        End Try

        Try
            Dim tb_Productos As Table
            tb_Productos = Db.Tables("Productos")
            tb_Productos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Proveedores] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Proveedores]")
        End Try

        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Entradas")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Entradas-Empleados] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Salidas-Empleados]")
        End Try

    End Sub

    Private Sub DataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataToolStripMenuItem.Click
        Dim query1 As String
        Try
            query1 = "insert into Productos (Nombre,Precio) values ('ZZZ',999)"
            Db.ExecuteWithResults(query1)
            query1 = "insert into Proveedores (Nombre,Direccion,Telefono,PaginaWeb) values ('XXX','AAA',666666,'WWW')"
            Db.ExecuteWithResults(query1)
            query1 = "insert into Empleados (Nombre,Direccion,Telefono,Correo) values ('YYY','BBB',77777,'CCC')"
            Db.ExecuteWithResults(query1)
            query1 = "insert into Saldos values (1,1,999,999,999)"
            Db.ExecuteWithResults(query1)
            query1 = "insert into Salidas  values (1,1,'11/11/2014','XXX')"
            Db.ExecuteWithResults(query1)

            MessageBox.Show("Data was created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create the new data")
        End Try

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim query1 As String = "ALTER TABLE Productos ADD FOREIGN KEY (IdProveedor) REFERENCES Proveedores(IdProveedor)"

            Db.ExecuteWithResults(query1)

            MessageBox.Show("Relation [Productos-Proveedores] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Proveedores]")
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Dim tb_Productos As Table
            tb_Productos = Db.Tables("Productos")
            tb_Productos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Proveedores] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Proveedores]")
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim tb_Entradas As Table
            tb_Entradas = New Table(Db, "Entradas")

            'Add various columns to the table.
            Dim col1 As Column
            col1 = New Column(tb_Entradas, "IdEntrada", DataType.Int)
            col1.Identity = True
            col1.IdentitySeed = 1
            col1.IdentityIncrement = 1
            tb_Entradas.Columns.Add(col1)

            Dim col2 As Column
            col2 = New Column(tb_Entradas, "IdProducto", DataType.Int)
            col2.Nullable = False
            tb_Entradas.Columns.Add(col2)

            Dim col3 As Column
            col3 = New Column(tb_Entradas, "IdEmpleado", DataType.Int)
            col3.Nullable = False
            tb_Entradas.Columns.Add(col3)

            Dim col4 As Column
            col4 = New Column(tb_Entradas, "Fecha", DataType.DateTime)
            col4.Nullable = False
            tb_Entradas.Columns.Add(col4)

            Dim col5 As Column
            col5 = New Column(tb_Entradas, "NombreCliente", DataType.VarChar(50))
            col5.Nullable = True


            Dim col6 As Column
            col6 = New Column(tb_Entradas, "Cantidad", DataType.Int)
            col6.Nullable = False
            tb_Entradas.Columns.Add(col6)

            Dim col7 As Column
            col7 = New Column(tb_Entradas, "UltimoPrecioU", DataType.Money)
            col7.Nullable = True
            tb_Entradas.Columns.Add(col7)

            tb_Entradas.Create()

            Dim query As String = "ALTER TABLE Entradas ADD PRIMARY KEY (IdEntrada)"
            Db.ExecuteWithResults(query)

            MessageBox.Show("Table [Entradas] created successfuly on DataBase " + Db.Name)

        Catch
            MessageBox.Show("Unable to create table: Entradas")
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            Dim query1 As String = "ALTER TABLE Entradas ADD FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)"
            Dim query2 As String = "ALTER TABLE Entradas ADD FOREIGN KEY (IdEmpleado) REFERENCES Empleados(IdEmpleado)"

            Db.ExecuteWithResults(query1)
            Db.ExecuteWithResults(query2)

            MessageBox.Show("Relation [Productos-Salidas-Entradas] created successfuly")
        Catch ex As Exception
            MessageBox.Show("Unable to create Relation [Productos-Salidas-Entradas]")
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            Dim tb_Saldos As Table
            tb_Saldos = Db.Tables("Entradas")
            tb_Saldos.ForeignKeys(0).Drop()
            tb_Saldos.ForeignKeys(0).Drop()
            MessageBox.Show("Relation [Productos-Entradas-Empleados] was deleted successfuly")

        Catch ex As Exception
            MessageBox.Show("Unable to delete Relation [Productos-Salidas-Empleados]")
        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        'Try
        '    Dim tb_Historico As Table
        '    tb_Historico = New Table(Db, "Historico")

        '    'Add various columns to the table.
        '    Dim col1 As Column
        '    col1 = New Column(tb_Historico, "IdSalida", DataType.Int)
        '    col1.Identity = True
        '    col1.IdentitySeed = 1
        '    col1.IdentityIncrement = 1
        '    tb_Historico.Columns.Add(col1)

        '    Dim col2 As Column
        '    col2 = New Column(tb_Historico, "IdProducto", DataType.Int)
        '    col2.Nullable = False
        '    tb_Historico.Columns.Add(col2)

        '    Dim col3 As Column
        '    col3 = New Column(tb_Historico, "IdEmpleado", DataType.Int)
        '    col3.Nullable = False
        '    tb_Historico.Columns.Add(col3)

        '    Dim col4 As Column
        '    col4 = New Column(tb_Historico, "Fecha", DataType.DateTime)
        '    col4.Nullable = False
        '    tb_Historico.Columns.Add(col4)

        '    Dim col5 As Column
        '    col5 = New Column(tb_Historico, "NombreCliente", DataType.VarChar(50))
        '    col5.Nullable = True
        '    tb_Historico.Columns.Add(col5)

        '    Dim col6 As Column
        '    col6 = New Column(tb_Historico, "Cantidad", DataType.Int)
        '    col6.Nullable = False

        '    Dim col7 As Column
        '    col7 = New Column(tb_Historico, "Descuento", DataType.Float)
        '    col7.Nullable = True

        '    Dim col8 As Column
        '    col8 = New Column(tb_Historico, "Total", DataType.Float)
        '    col8.Nullable = True

        '    tb_Historico.Create()

        '    Dim query As String = "ALTER TABLE Salidas ADD PRIMARY KEY (IdSalida)"
        '    Db.ExecuteWithResults(query)

        '    MessageBox.Show("Table [Historico] created successfuly on DataBase " + Db.Name)
        'Catch
        '    MessageBox.Show("Unable to create table: Historico")
        'End Try
    End Sub
End Class
