using System.Collections.Generic;

namespace Paulo.Core
{
    public interface IService<TEntity>
    {
        /// <summary>
        /// Adiciona um item
        /// </summary>
        /// <param name="obj"></param>
        void Add(TEntity obj);

        /// <summary>
        /// Busca um item pelo id
        /// </summary>
        /// <param name="id">Id da entidade</param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Busca todos os itens de uma tabela
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();

        /// <summary>
        /// Busca dos os itens de uma tabela que 
        /// contem nos ids passados por parametro
        /// </summary>
        /// <param name="ids">Ids da entidade</param>
        /// <returns></returns>
        List<TEntity> GetAllByIds(List<int> ids);

        /// <summary>
        /// Atualiza um item
        /// </summary>
        /// <param name="obj">Item que será atualizado</param>
        void Update(TEntity obj);

        /// <summary>
        /// Remove um item pelo id
        /// </summary>
        /// <param name="id">Id do item</param>
        void Remove(int id);

        /// <summary>
        /// Remove todos os itens que 
        /// contem nos ids passados por parametro
        /// </summary>
        /// <param name="ids"></param>
        void RemoveMany(List<int> ids);
    }
}
