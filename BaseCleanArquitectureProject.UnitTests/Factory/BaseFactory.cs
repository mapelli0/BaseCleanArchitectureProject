using System.Reflection.Metadata.Ecma335;

namespace BaseCleanArquitectureProject.UnitTests.Builders {

	public abstract class BaseFactory<T> where T: new() {
		protected readonly T Entity = new T();

		public T Build() {
			return Entity;
		}
	}

}