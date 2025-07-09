-- Usuario admin
INSERT INTO usuarios (nombre, apellido, email, telefono, contrasena_hash, rol, activo)
VALUES ('Admin', 'Sarmiento', 'admin@sarmimovie.com', '0000000000', 'Bhbbu8g3cG21oJTTBgP0RAmRURnvTBu/5PaTP8Kr68U=', 'Admin', 1);

-- Sucursales
INSERT INTO sucursales (nombre, ubicacion) VALUES ('Sucursal Norte', 'Av. Las Flores 123, Lima');
INSERT INTO sucursales (nombre, ubicacion) VALUES ('Sucursal Sur', 'Av. Los Pinos 456, Arequipa');
INSERT INTO sucursales (nombre, ubicacion) VALUES ('Sucursal Este', 'Av. El Sol 789, Cusco');
INSERT INTO sucursales (nombre, ubicacion) VALUES ('Sucursal Oeste', 'Av. La Luna 321, Trujillo');
INSERT INTO sucursales (nombre, ubicacion) VALUES ('Sucursal Central', 'Av. Principal 987, Lima');

-- Películas
INSERT INTO peliculas (titulo, descripcion, genero, duracion, clasificacion, idioma, sinopsis, imagen)
VALUES ('El Viaje Intergaláctico', 'Una aventura espacial...', 'Ciencia Ficción', 120, 'PG-13', 'Español', 'Un astronauta perdido...', 'viaje.jpg');
INSERT INTO peliculas (titulo, descripcion, genero, duracion, clasificacion, idioma, sinopsis, imagen)
VALUES ('Amor en los Tiempos Modernos', 'Una comedia romántica...', 'Romance', 105, 'PG', 'Español', 'El amor florece...', 'amor.jpg');
INSERT INTO peliculas (titulo, descripcion, genero, duracion, clasificacion, idioma, sinopsis, imagen)
VALUES ('La Maldición del Lago', 'Terror sobrenatural...', 'Terror', 95, 'R', 'Español', 'Una leyenda renace...', 'maldicion.jpg');
INSERT INTO peliculas (titulo, descripcion, genero, duracion, clasificacion, idioma, sinopsis, imagen)
VALUES ('Código Mortal', 'Acción y suspenso...', 'Acción', 110, 'PG-13', 'Español', 'Un hacker peligroso...', 'codigo.jpg');
INSERT INTO peliculas (titulo, descripcion, genero, duracion, clasificacion, idioma, sinopsis, imagen)
VALUES ('El Gran Chef', 'Competencia culinaria...', 'Comedia', 100, 'PG', 'Español', 'Recetas y risas...', 'chef.jpg');

-- Salas
INSERT INTO salas (nombre, tipo, capacidad, id_sucursal) VALUES ('Sala 1', 'IMAX', 20, 1);
INSERT INTO salas (nombre, tipo, capacidad, id_sucursal) VALUES ('Sala 2', '2D', 20, 2);
INSERT INTO salas (nombre, tipo, capacidad, id_sucursal) VALUES ('Sala 3', '3D', 20, 3);
INSERT INTO salas (nombre, tipo, capacidad, id_sucursal) VALUES ('Sala 4', '2D', 20, 4);
INSERT INTO salas (nombre, tipo, capacidad, id_sucursal) VALUES ('Sala 5', '3D', 20, 5);


-- Asientos
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'A', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'A', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'A', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'A', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'A', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'B', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'B', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'B', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'B', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'B', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'C', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'C', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'C', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'C', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'C', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'D', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'D', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'D', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'D', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (1, 'D', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'A', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'A', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'A', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'A', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'A', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'B', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'B', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'B', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'B', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'B', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'C', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'C', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'C', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'C', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'C', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'D', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'D', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'D', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'D', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (2, 'D', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'A', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'A', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'A', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'A', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'A', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'B', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'B', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'B', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'B', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'B', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'C', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'C', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'C', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'C', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'C', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'D', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'D', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'D', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'D', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (3, 'D', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'A', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'A', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'A', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'A', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'A', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'B', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'B', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'B', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'B', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'B', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'C', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'C', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'C', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'C', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'C', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'D', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'D', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'D', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'D', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (4, 'D', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'A', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'A', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'A', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'A', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'A', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'B', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'B', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'B', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'B', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'B', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'C', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'C', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'C', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'C', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'C', 5);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'D', 1);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'D', 2);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'D', 3);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'D', 4);
INSERT INTO asientos (sala_id, fila, numero) VALUES (5, 'D', 5);


-- Tipos de boleto
INSERT INTO tipos_boleto (nombre) VALUES ('Adulto');
INSERT INTO tipos_boleto (nombre) VALUES ('Niño');
INSERT INTO tipos_boleto (nombre) VALUES ('Senior');

-- Métodos de pago
INSERT INTO metodos_pago (nombre) VALUES ('Tarjeta');
INSERT INTO metodos_pago (nombre) VALUES ('Efectivo');
INSERT INTO metodos_pago (nombre) VALUES ('Yape');
INSERT INTO metodos_pago (nombre) VALUES ('Plin');
INSERT INTO metodos_pago (nombre) VALUES ('Transferencia');

-- Funciones
INSERT INTO funciones (pelicula_id, sala_id, sucursal_id, fecha, hora_inicio, hora_fin, idioma, formato, estado)
VALUES (13, 1, 1, CURDATE(), '18:00:00', '20:00:00', 'Español', '2D', 'Activa');
INSERT INTO funciones (pelicula_id, sala_id, sucursal_id, fecha, hora_inicio, hora_fin, idioma, formato, estado)
VALUES (13, 2, 2, CURDATE(), '18:00:00', '20:00:00', 'Español', '2D', 'Activa');
INSERT INTO funciones (pelicula_id, sala_id, sucursal_id, fecha, hora_inicio, hora_fin, idioma, formato, estado)
VALUES (13, 3, 3, CURDATE(), '18:00:00', '20:00:00', 'Español', '2D', 'Activa');
INSERT INTO funciones (pelicula_id, sala_id, sucursal_id, fecha, hora_inicio, hora_fin, idioma, formato, estado)
VALUES (13, 4, 4, CURDATE(), '18:00:00', '20:00:00', 'Español', '2D', 'Activa');
INSERT INTO funciones (pelicula_id, sala_id, sucursal_id, fecha, hora_inicio, hora_fin, idioma, formato, estado)
VALUES (13, 5, 5, CURDATE(), '18:00:00', '20:00:00', 'Español', '2D', 'Activa');


-- Asientos por función
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'A1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'A2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'A3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'A4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'A5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'B1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'B2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'B3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'B4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (1, 'B5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'A1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'A2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'A3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'A4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'A5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'B1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'B2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'B3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'B4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (2, 'B5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'A1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'A2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'A3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'A4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'A5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'B1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'B2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'B3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'B4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (3, 'B5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'A1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'A2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'A3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'A4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'A5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'B1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'B2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'B3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'B4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (4, 'B5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'A1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'A2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'A3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'A4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'A5', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'B1', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'B2', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'B3', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'B4', TRUE);
INSERT INTO asientos_funcion (funcion_id, asiento, disponible) VALUES (5, 'B5', TRUE);


-- Precios por tipo de boleto
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (1, 1, 18.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (1, 2, 16.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (1, 3, 14.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (2, 1, 18.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (2, 2, 16.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (2, 3, 14.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (3, 1, 18.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (3, 2, 16.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (3, 3, 14.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (4, 1, 18.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (4, 2, 16.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (4, 3, 14.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (5, 1, 18.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (5, 2, 16.00);
INSERT INTO precios_funcion (funcion_id, tipo_boleto_id, precio) VALUES (5, 3, 14.00);

