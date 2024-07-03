# 2º PARCIAL LABORATORIO DE COMPUTACIÓN - PARACHE FELIPE
# PROYECTO CRUD - GAMING STORE

## Sobre mi
Mi nombre es Felipe Parache y tengo 22 años. Vivo en Villa del Parque y soy parte del primer equipo de handball en el Club Comunicaciones, además trabajo de camarógrafo para la Federación Metropolitana de Balonmano. Cuando terminé mis estudios secundarios no sabía que carrera seguir y me anoté en el curso de desarrollo web en CoderHouse donde aprendí lo básico en HTML, CSS y JavaScript. Posteriormente encontré la Tecnicatura Universitaria en Programación en la UTN y no dudé en anotarme.

## Resumen  

La aplicación simula una tienda de consolas.
Al iniciarse, se le pedirá al usuario que ingrese su correo y clave, en caso de ser correctos podrá ingresar al CRUD. Dependiendo de su perfil administrativo, tendrá acceso a hacer tal o cuales cosas.  
Dentro podrá elegir qué consola agregar presionando uno de los botones "PlayStation", "Nintendo" o "Xbox". Una vez seleccionadda la marca de la consola, podrá elegir el modelo, almacenamiento, videojuego y algunos elementos más, propios de cada consola. Una vez finalizada la elección, se agregará automaticamente a la base de datos conectada con la aplicación y se mostrará en el visor. Si desea ver los demás atributos que tiene la consola elegida, deberá seleccionarla y luego pulsar en el botón "Ver en detalle". Para modificar algún elemento que no sea el modelo o el almacenamiento, deberá elegirla y clickear el botón "Modificar"; los cambios se guardarán en la base de datos. El boton "Eliminar" borrará la consola del visor y permanentemente de la base de datos. 
Además, si el usuario agrega varias consolas, podrá ordenarlas por año de fabricación y por marca, seleccionando el radio button correspondiente.
Es posible guardar la selección de consolas en el lugar que se desee de la computadora, como también abrir un archivo que contenga una seleccion creada anteriormente. Asimismo, si el usuario ya había agregado consolas en la base de datos, es posible recuperarlas al hacer click en el botón "Abrir SQL" y poder trabajar con ellas.  

## El script de la base de datos se encuentra dentro del archivo ADO, dentro de la carpeta ScriptBDD

## Diagramas de clases

### Clase Consola (Padre)
<img width="728" alt="image" src="https://github.com/FelipeParache/Parache.Felipe.PrimerParcial./blob/segundoParcial/FrmGamingStore/Imagenes/diagramaClaseConsola.png">

### Clase PlayStation (Hija)
<img width="728" alt="image" src="https://github.com/FelipeParache/Parache.Felipe.PrimerParcial./blob/segundoParcial/FrmGamingStore/Imagenes/diagramaClasePlayStation.png">

### Clase Xbox (Hija)
<img width="728" alt="image" src="https://github.com/FelipeParache/Parache.Felipe.PrimerParcial./blob/segundoParcial/FrmGamingStore/Imagenes/diagramaClaseXbox.png">

### Clase Nintendo (Hija)
<img width="728" alt="image" src="https://github.com/FelipeParache/Parache.Felipe.PrimerParcial./blob/segundoParcial/FrmGamingStore/Imagenes/diagramaClaseNintendo.png">

### Clase Usuario, GamingStore y auxiliares
<img width="728" alt="image" src="https://github.com/FelipeParache/Parache.Felipe.PrimerParcial./blob/segundoParcial/FrmGamingStore/Imagenes/diagramasEntidades.png">
