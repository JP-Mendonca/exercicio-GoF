Exercício da disciplina de Programação Avançada
Autor: João Pedro Mendonça Oliveira

tst



O objetivo do exercício era implementar os 3 padrões de projetos: Adapter, Iterator e Singleton em uma única aplicação a escolha do
aluno. Eu acabei por escolher uma implementação que simula um servidor DHCP que distribui endereços IP em uma rede para dispositivos
conectados à mesma. O padrão Singleton foi o primeiro a ser feito, e foi aplicado ao servidor, que por ser uma entidade única da rede
teria que possuir apenas uma única instância nela. O segundo padrão aplicado foi o Adapter, utilizado com a classe Devices, fez muito
sentido para mim incorporar este padrão nesta classe por ela representar toda a gama de dispositivos que poderiam se conectar ao 
servidor e assim a cada novo dispositivo cria-se um adapter e por meio dele não é necessário fazer nenhuma reescrita no código apenas 
adicionar o novo dispositivo. O último padrão foi o Iterator, que foi utilizado para iterar sobre as DeviceList, que seriam listas de
dispositivos presentes no servidor.
