using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Repositories;
using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;

namespace ControlePedidos.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void Delete(int id)
        {
            var user = _clientRepository.GetById(id);

            if (user == null)            
                throw new Exception("Usuario não encontrado");

            _clientRepository.Delete(id);
            
        }

        public List<ClientModel> GetAll()
        {
            List<Client> clients = new List<Client>();

            clients = _clientRepository.GetAll();

            var response = MapClientList(clients);

            return response;
        }

        public ClientModel GetById(int id)
        {
            var client = _clientRepository.GetById(id);

            var response = MapClient(client);

            return response;
        }

        public void Insert(InsertClientModel request)
        {
            Client client = new Client
            {
                Name = request.Name,
                Email = request.Email,
                Contact = request.Contact,
                Cpf = request.Cpf
            };

            _clientRepository.Insert(client);
        }

        public void Update(ClientModel client)
        {
            // Obter o cliente existente pelo ID
            var existingClient = _clientRepository.GetById(client.Id);

            // Verificar se o cliente existe
            if (existingClient != null)
            {
                // Atualizar apenas os campos que estão preenchidos no modelo de atualização
                if (!string.IsNullOrEmpty(client.Name))
                {
                    existingClient.Name = client.Name;
                }

                if (!string.IsNullOrEmpty(client.Email))
                {
                    existingClient.Email = client.Email;
                }

                if (!string.IsNullOrEmpty(client.Contact))
                {
                    existingClient.Contact = client.Contact;
                }                

                // Chamar o método de atualização no repositório
                _clientRepository.Update(existingClient);
            }
            else
            {
                throw new Exception($"Cliente com ID {client.Id} não encontrado.");

            }
        }


        private ClientModel MapClient(Client client)
        {

            var clientModel = new ClientModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Contact = client.Contact
            };

            return clientModel;

        }
        private List<ClientModel> MapClientList(List<Client> list)
        {

            List<ClientModel> response = new List<ClientModel>();

            foreach (var item in list)
            {
                var clientDto = new ClientModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Contact = item.Contact
                };

                response.Add(clientDto);
            }

            return response;

        }
    }
}
