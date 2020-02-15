# ejemplosOA
Este repositorio contiene 3 ejemplos distintos sobre cómo implementar Orientación a Aspectos, cada uno en una solución diferente.
Se trata de aplicaciones sencillas de consola.

La aplicación simula una cuenta bancaria donde podemos ingresar/extraer/consultar nuestro dinero (clase Account) y se muestra por pantalla las acciones que se han realizado (la ejecución de los aspectos se muestra con un color de fuente distinto). El código de los aspectos se encuentra en la carpeta Aspects y se han implementado tanto trazas (LoggingAdvice) como autenticación (AuthenticationAdvice - la autenticación es un 'mock', no está implementada como tal).

Los ejemplos son:
* EjemploRealProxy: implementación aplicando el patrón Decorador y la clase RealProxy.
* EjemploUnity: implementación mediante el framework Unity de inyección de dependencias.
* EjemploPostSharp: implementación mediante el framework PostSharp para programación Orientada a Aspectos. Para que funcione correctamente, es necesario descargarlo (https://www.postsharp.net/, dispone de versión gratuita limitada pero suficiente para probar).
