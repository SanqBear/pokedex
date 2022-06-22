using Pokedex.Model.Definitions;
using System.Collections;

namespace Pokedex.Model.Repositories
{
    public class PokedexContext : BaseContext
    {
        public PokedexContext(string connectionString) : base(connectionString)
        {
        }

        #region INSERT

        public async Task<bool> InsertMapPokemonAttributeAsync(string pokemonId, string attributeId, string gen, bool isHidden)
        {
            var parameters = new Hashtable();

            parameters.Add("PokemonId", pokemonId);
            parameters.Add("AttributeId", attributeId);
            parameters.Add("Gen", gen);
            parameters.Add("IsHiddenYN", isHidden ? "Y" : "N");

            return await ExecuteQueryAsync("[dbo].[up_INSERT_mapPokemonAttribute]", parameters);
        }

        public async Task<bool> InsertPokemonStatusAsync(string pokemonId, string gen, int hp, int atk, int def, int spatk, int spdef, int spd)
        {
            var parameters = new Hashtable();

            parameters.Add("PokemonId", pokemonId);
            parameters.Add("Gen", gen);
            parameters.Add("Health", hp);
            parameters.Add("Attack", atk);
            parameters.Add("Defense", def);
            parameters.Add("SpAttack", spatk);
            parameters.Add("SpDefense", spdef);
            parameters.Add("Speed", spd);

            return await ExecuteQueryAsync("[dbo].[up_INSERT_tbPokemonStatus]", parameters);
        }

        public async Task<bool> InsertAttributeAsync(string attributeId, string name, string desc)
        {
            var parameters = new Hashtable();

            parameters.Add("AttributeId", attributeId);
            parameters.Add("Name", name);
            parameters.Add("Desc", desc);

            return await ExecuteQueryAsync("[dbo].[up_INSERT_tbAttribute]", parameters);
        }

        public async Task<bool> InsertMoveAsync(string moveId, string gen, string name, string desc, int pp, int power)
        {
            var parameters = new Hashtable();

            parameters.Add("MoveId", moveId);
            parameters.Add("Gen", gen);
            parameters.Add("Name", name);
            parameters.Add("Desc", desc);
            parameters.Add("PP", pp);
            parameters.Add("Power", power);

            return await ExecuteQueryAsync("[dbo].[up_INSERT_tbMove]", parameters);
        }

        public async Task<bool> InsertTagAsync(string tagId, string name, string desc)
        {
            var parameters = new Hashtable();

            parameters.Add("TagId", tagId);
            parameters.Add("Name", name);
            parameters.Add("Desc", desc);

            return await ExecuteQueryAsync("[dbo].[up_INSERT_tbTag]", parameters);
        }

        public async Task<bool> InsertMapPokemonMoveAsync(string pokemonId, string moveId, string gen, MoveEarnType earnType, string earnDesc)
        {
            var parameters = new Hashtable();

            parameters.Add("PokemonId", pokemonId);
            parameters.Add("MoveId", moveId);
            parameters.Add("Gen", gen);
            parameters.Add("EarnType", earnType.ToString());
            parameters.Add("Desc", earnDesc);

            return await ExecuteQueryAsync("[dbo].[up_INSERT_mapPokemonMove]", parameters);
        }

        #endregion INSERT
    }
}