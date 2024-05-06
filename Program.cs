using MathNet.Numerics.Distributions;

class Program
{
    static void Main()
    {

        Console.WriteLine("Ejercicio 6.9");
        // Media
        double media = 110;
        // Valor inferior del intervalo para el 99% de los individuos
        double valorInferior = 85;
        // Valor superior del intervalo para el 99% de los individuos
        double valorSuperior = 135;
        // Porcentaje del intervalo que contiene al 70% de los valores
        double porcentajeIntervalo = 0.70;

        // Desviación estándar
        double desviacionEstandar = (valorSuperior - media) / 2.575; // Utilizamos 2.575 para el valor de Z correspondiente al 99%

        // Límites del intervalo que contiene al 70% de los valores
        double k = 1.036; // Valor correspondiente a P(Z < k) = 0.85 en la distribución normal estándar
        double limiteInferiorIntervalo = media - desviacionEstandar * k;
        double limiteSuperiorIntervalo = media + desviacionEstandar * k;

        // Porcentajes solicitados
        double porcentajeSuperior135 = 1 - Normal.CDF(media, desviacionEstandar, valorSuperior);
        double porcentajeInferior95 = Normal.CDF(media, desviacionEstandar, 95);
        double porcentajeEntre90y125 = Normal.CDF(media, desviacionEstandar, 125) - Normal.CDF(media, desviacionEstandar, 90);
        double porcentajeEntre85y100 = Normal.CDF(media, desviacionEstandar, 100) - Normal.CDF(media, desviacionEstandar, 85);

        // Resultados
        Console.WriteLine("Desviación estándar: " + desviacionEstandar);
        Console.WriteLine("Intervalo que contiene al 70% de los valores: [" + limiteInferiorIntervalo + ", " + limiteSuperiorIntervalo + "]");
        Console.WriteLine("a) Porcentaje de población con concentración superior a 135: " + porcentajeSuperior135 * 100 + "%");
        Console.WriteLine("b) Porcentaje de población con concentración inferior a 95: " + porcentajeInferior95 * 100 + "%");
        Console.WriteLine("c) Porcentaje de población con concentración entre 90 y 125: " + porcentajeEntre90y125 * 100 + "%");
        Console.WriteLine("d) Porcentaje de población con concentración entre 85 y 100: " + porcentajeEntre85y100 * 100 + "%");

        Console.WriteLine("\nEjercicio 6.10");

        // Probabilidades dadas
        double prob1 = 0.58; // P(X < 165) = 58%
        double prob2 = 0.38; // P(165 <= X < 180) = 38%

        // Límites de índices de colesterol
        double limiteInferior = 165;
        double limiteSuperior = 180;

        // Crear distribución normal estándar para hallar z
        var normal = new Normal(0, 1);

        // Calcular valores z para las probabilidades
        double zInferior = normal.InverseCumulativeDistribution(prob1);
        double zSuperior = normal.InverseCumulativeDistribution(prob1 + prob2);

        // Calcular desviación estándar y media2
        double desviacion2 = (limiteSuperior - limiteInferior) / (zSuperior - zInferior);
        double media2 = limiteInferior - zInferior * desviacion2;

        // Mostrar resultados de media2 y desviación2
        Console.WriteLine($"Media: {media2:F2}");
        Console.WriteLine($"Desviación: {desviacion2:F2}");

        // Límite de tratamiento
        double limiteTratamiento = 183;

        // Calcular z para el límite de tratamiento
        double zTratamiento = (limiteTratamiento - media2) / desviacion2;

        // Calcular probabilidad de necesitar tratamiento
        double probTratamiento = 1 - normal.CumulativeDistribution(zTratamiento);

        // Población total
        int poblacionTotal = 100000;

        // Calcular número de personas que necesitan tratamiento
        int personasTratamiento = (int)(poblacionTotal * probTratamiento);

        // Mostrar resultados finales
        Console.WriteLine($"Probabilidad de índice de colesterol > 183: {probTratamiento:P2}");
        Console.WriteLine($"Personas que necesitan tratamiento: {personasTratamiento}");

        Console.WriteLine("\nEjercicio 6.11");
        // Definición de las probabilidades
        double probabilidad1 = 0.95; // Para P(X > x) = 0.95
        double probabilidad2 = 0.33; // Para P(X < y) = 0.33
        double probabilidad3 = 0.77; // Para P(X < 12) = 0.77
        double probabilidad4 = 0.84; // Para P(X > 7) = 0.84

        // Cálculo de los valores z
        double valorZ1 = Normal.InvCDF(0, 1, 1 - probabilidad1); // Para P(X > x)
        double valorZ2 = Normal.InvCDF(0, 1, probabilidad2); // Para P(X < y)
        double valorZ3 = Normal.InvCDF(0, 1, probabilidad3); // Para P(X < 12)
        double valorZ4 = Normal.InvCDF(0, 1, 1 - probabilidad4); // Para P(X > 7)

        // Cálculo de mu y sigma
        double sigma = (12 - 7) / (valorZ3 - valorZ4);
        double mu = 12 - sigma * valorZ3;

        // Cálculo de x e y
        double x = mu + valorZ1 * sigma;
        double y = mu + valorZ2 * sigma;

        // Cálculo de la proporción entre 8 y 10 milímetros
        double valorZ5 = (8 - mu) / sigma;
        double valorZ6 = (10 - mu) / sigma;
        double proporcion = Normal.CDF(0, 1, valorZ6) - Normal.CDF(0, 1, valorZ5);

        // Imprimir los resultados de forma más descriptiva
        Console.WriteLine("a) Media (mu) aproximada: " + mu);
        Console.WriteLine("   Desviación estándar (sigma) aproximada: " + sigma);
        Console.WriteLine("b) Proporción de individuos entre 8 y 10 milímetros: " + proporcion);
        Console.WriteLine("c) Valor aproximado de x: " + x);
        Console.WriteLine("   Valor aproximado de y: " + y);

        Console.WriteLine("\nEjercicio 6.12");
        int n = 20; // Número de ensayos
        double p = 0.4; // Probabilidad de éxito en cada ensayo

        // Media y desviación estándar de la distribución binomial
        double media3 = n * p;
        double desviacionEstandar3 = Math.Sqrt(n * p * (1 - p));

        // Corrección de continuidad
        double x3 = 11.5;

        // Calcula Z
        double z = (x3 - media3) / desviacionEstandar3;

        // Calcula la probabilidad utilizando la distribución normal acumulativa
        double probabilidad = Normal.CDF(0, 1, z);

        // Probabilidad de que X >= 12
        double resultado = 1 - probabilidad;

        Console.WriteLine("La probabilidad de que 12 o más niños afectados tengan madres que fumaban es: {0}", resultado.ToString("0.0000"));
    }
}