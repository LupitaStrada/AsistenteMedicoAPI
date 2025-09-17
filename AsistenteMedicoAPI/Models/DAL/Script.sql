CREATE DATABASE asistentemedico;
-- ===== MYSQL SCRIPT PARA EL SISTEMA DE GESTIÓN DE CLÍNICA MÉDICA =====
-- Se recomienda ejecutar en MySQL Workbench o phpMyAdmin.

-- Creación de la base de datos si no existe

USE asistentemedico;

-- ===== TABLA CENTROS MÉDICOS =====
CREATE TABLE CentrosMedicos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(200) NOT NULL,
    Direccion VARCHAR(300),
    Telefono VARCHAR(20),
    Email VARCHAR(150),
    SitioWeb VARCHAR(200),
    HorarioInicio TIME DEFAULT '08:00:00',
    HorarioFin TIME DEFAULT '18:00:00',
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ===== TABLA ESPECIALIDADES =====
CREATE TABLE Especialidades (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE,
    Descripcion VARCHAR(300),
    Color VARCHAR(7) DEFAULT '#0066CC',
    DuracionPredeterminadaMinutos INT DEFAULT 30,
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- ===== TABLA MÉDICOS (OPTIMIZADA) =====
CREATE TABLE Medicos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CentroId INT NOT NULL,
    PrimerNombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE,
    Telefono VARCHAR(20),
    NumeroLicencia VARCHAR(50),
    ImagenPerfil VARCHAR(500),
    Biografia TEXT,
    TarifaConsulta DECIMAL(10,2) DEFAULT 0,
    
    -- Configuraciones básicas
    DuracionCitaPredeterminada INT DEFAULT 30,
    CitasDiariasMax INT DEFAULT 20,
    PermitirReservaEnLinea BOOLEAN DEFAULT TRUE,
    
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (CentroId) REFERENCES CentrosMedicos(Id)
);

-- ===== TABLA MÉDICO-ESPECIALIDADES (RELACIÓN MUCHOS A MUCHOS) =====
CREATE TABLE MedicoEspecialidades (
    MedicoId INT NOT NULL,
    EspecialidadId INT NOT NULL,
    EsPrincipal BOOLEAN DEFAULT FALSE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    PRIMARY KEY (MedicoId, EspecialidadId),
    FOREIGN KEY (MedicoId) REFERENCES Medicos(Id) ON DELETE CASCADE,
    FOREIGN KEY (EspecialidadId) REFERENCES Especialidades(Id)
);

-- ===== TABLA HORARIOS MÉDICOS =====
CREATE TABLE HorariosMedicos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    MedicoId INT NOT NULL,
    DiaDeSemana INT NOT NULL, -- 1=Lunes, 7=Domingo
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    FOREIGN KEY (MedicoId) REFERENCES Medicos(Id) ON DELETE CASCADE,
    CHECK (DiaDeSemana BETWEEN 1 AND 7)
);

-- ===== TABLA PACIENTES =====
CREATE TABLE Pacientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CentroId INT NOT NULL,
    PrimerNombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Email VARCHAR(150),
    FechaNacimiento DATE,
    Genero ENUM('M', 'F', 'Otro'),
    
    -- Contacto de emergencia básico
    ContactoEmergencia VARCHAR(150),
    TelefonoEmergencia VARCHAR(20),
    
    -- Preferencias de comunicación
    RecibirSms BOOLEAN DEFAULT TRUE,
    RecibirEmail BOOLEAN DEFAULT TRUE,
    
    -- Sistema
    NumeroPaciente VARCHAR(10),
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    UltimaVisita TIMESTAMP NULL,
    
    FOREIGN KEY (CentroId) REFERENCES CentrosMedicos(Id)
);

-- ===== TABLA TIPOS DE CITA =====
CREATE TABLE TiposCita (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CentroId INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(300),
    DuracionMinutos INT DEFAULT 30,
    Precio DECIMAL(10,2) DEFAULT 0,
    Color VARCHAR(7) DEFAULT '#0066CC',
    EstaActivo BOOLEAN DEFAULT TRUE,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    
    FOREIGN KEY (CentroId) REFERENCES CentrosMedicos(Id)
);

-- ===== TABLA CITAS (OPTIMIZADA) =====
CREATE TABLE Citas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    CentroId INT NOT NULL,
    PacienteId INT NOT NULL,
    MedicoId INT NOT NULL,
    TipoCitaId INT,
    
    -- Detalles de la cita
    FechaCita DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Estado ENUM('Agendada', 'Confirmada', 'En_Curso', 'Completada', 'Cancelada', 'No_Show') DEFAULT 'Agendada',
    
    -- Información básica
    Motivo VARCHAR(300),
    Notas TEXT,
    NotasMedicas TEXT, -- Para uso exclusivo del médico
    
    -- Pagos básicos
    Precio DECIMAL(10,2) DEFAULT 0,
    EstaPagada BOOLEAN DEFAULT FALSE,
    MetodoPago VARCHAR(50),
    
    -- Sistema
    CreadaPor VARCHAR(100) DEFAULT 'Sistema',
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FechaActualizacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (CentroId) REFERENCES CentrosMedicos(Id),
    FOREIGN KEY (PacienteId) REFERENCES Pacientes(Id),
    FOREIGN KEY (MedicoId) REFERENCES Medicos(Id),
    FOREIGN KEY (TipoCitaId) REFERENCES TiposCita(Id)
);