CREATE TABLE Autor (
    IdAutor INT IDENTITY(1,1) PRIMARY KEY,
    NombreAutor VARCHAR(100),
    NacionalidadAutor VARCHAR(100),
    FechaNacimientoAutor SMALLDATETIME
);

CREATE TABLE Lector (
    Identifiacion INT PRIMARY KEY,
    NombreLector VARCHAR(100),
    FechaNacimientoLec SMALLDATETIME,
    TelefonoLector INT,
    CorreoLector VARCHAR(150)
);

CREATE TABLE Libro (
    IdLibro INT IDENTITY(1,1) PRIMARY KEY,
    NombreLibro VARCHAR(100),
    TipoLibro VARCHAR(100),
    EditorialLibro VARCHAR(100),
    AnoLibro INT,
    IdAutor INT FOREIGN KEY REFERENCES Autor(IdAutor)
);

CREATE TABLE Copia (
    IdCopia INT IDENTITY(1,1) PRIMARY KEY,
    Estado VARCHAR(100),
    IdLibro INT FOREIGN KEY REFERENCES Libro(IdLibro)
);

CREATE TABLE Prestamo (
    IdPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    IdLector INT FOREIGN KEY REFERENCES Lector(Identifiacion),
    IdCopia INT FOREIGN KEY REFERENCES Copia(IdCopia)
);


CREATE TABLE EstadoPrestamo (
    IdEstadoPrestamo INT IDENTITY(1,1) PRIMARY KEY,
    FechaPrestamo SMALLDATETIME,
    FechaEstEntrega SMALLDATETIME,
    FechaEntrega SMALLDATETIME,
    IdPrestamo INT FOREIGN KEY REFERENCES Prestamo(IdPrestamo)
);

