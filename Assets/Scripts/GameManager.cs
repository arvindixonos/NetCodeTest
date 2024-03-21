using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;


namespace VRARRI
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] NetworkManager networkManager;

        [SerializeField] UnityTransport unityTransport;

        private void OnEnable()
        {
            networkManager.OnClientDisconnectCallback += NetworkManager_OnClientDisconnectCallback;
            networkManager.OnClientConnectedCallback += NetworkManager_OnClientConnectedCallback;
            networkManager.OnTransportFailure += NetworkManager_OnTransportFailure;
            networkManager.OnConnectionEvent += NetworkManager_OnConnectionEvent;

            unityTransport.OnTransportEvent += UnityTransport_OnTransportEvent;
        }

        void Start()
        {
            StartCoroutine(StartConnection());
        }

        IEnumerator StartConnection()
        {
            networkManager.StartClient();

            yield return new WaitForSeconds(3f);

            if(!networkManager.IsConnectedClient)
            {
                networkManager.Shutdown();

                yield return new WaitForSeconds(3f);

                networkManager.StartHost();
            }
        }

        private void UnityTransport_OnTransportEvent(NetworkEvent eventType, ulong clientId, System.ArraySegment<byte> payload, float receiveTime)
        {
        }

        private void NetworkManager_OnConnectionEvent(NetworkManager arg1, ConnectionEventData arg2)
        {
        }

        private void NetworkManager_OnTransportFailure()
        {
        }

        private void NetworkManager_OnClientConnectedCallback(ulong obj)
        {
        }

        private void NetworkManager_OnClientDisconnectCallback(ulong obj)
        {
        }

        void Update()
        {

        }
    }
}