using System.Collections.Generic;

namespace Algorithms.Helpers
{
    public static class ListFunctions
	{

        /// <summary>
        /// Faz a troca de dois objetos de um vetor.
        /// </summary>
        /// <typeparam name="E"> Tipo do objeto do vetor.</typeparam>
        /// <param name="list">Vetor de entrada.</param>
        /// <param name="source">Posição onde irá ser feita a troca.</param>
        /// <param name="destination">Posição onde irá ser feita a troca.</param>
        public static void Swap<T>(IList<T> list, int source, int destination)
        {
            T temp = list[source];
            list[source] = list[destination];
            list[destination] = temp;
        }
    }
}
