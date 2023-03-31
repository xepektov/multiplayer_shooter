using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class HealthChanged : UnityEvent<float, float> { }

[RequireComponent(typeof(PhotonView))]
public class Health : MonoBehaviour, IDamageable, IPunObservable
{
	public HealthChanged OnHealthChanged;
	[SerializeField] private float m_maxHealth = 150;
	public float m_currentHealth;
	private PhotonView PV;
	private Player m_lastHit;

	player_manager_photon_script player_Manager_Photon_Script;

	public Image health_bar;

	[SerializeField] GameObject ui;

	private void Awake()
	{
		PV = GetComponent<PhotonView>();
		player_Manager_Photon_Script = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<player_manager_photon_script>();
	}

	private void Start()
	{
		HandleObservable();

        if (!PV.IsMine)
        {
			Destroy(ui);
        }

		m_currentHealth = m_maxHealth;
		OnHealthChanged.Invoke(m_currentHealth, m_maxHealth);

		health_bar.fillAmount = 1;
		health_bar.fillAmount = m_currentHealth / m_maxHealth;
	}

	private void HandleObservable()
	{
		if (!PV.ObservedComponents.Contains(this))
		{
			PV.ObservedComponents.Add(this);
		}
	}

	/// <summary>
	/// Send an damage RPC to the objects owner.
	/// </summary>
	/// <param name="amount">How much damage should be dealt.</param>
	public void ApplyDamage(float amount)
	{
		if (PV.IsSceneView)
		{
			//used to apply damage to scene objects
			var info = new PhotonMessageInfo(PhotonNetwork.LocalPlayer,
											 PhotonNetwork.ServerTimestamp, null);
			ApplyDamageInternal(amount, info);
		}
		else
		{
			PV.RPC(nameof(ApplyDamageInternal), PV.Owner, amount);
		}
	}

	/// <summary>
	/// Send an heal RPC to the objects owner.
	/// </summary>
	public void ApplyHealth(float amount)
	{
		if (PV.IsSceneView)
		{
			ApplyHealthInternal(amount);
		}
		else
		{
			PV.RPC(nameof(ApplyHealthInternal), PV.Owner, amount);
		}
	}

	[PunRPC]
	private void ApplyDamageInternal(float amount, PhotonMessageInfo info)
	{
		m_lastHit = info.Sender;

		m_currentHealth = Mathf.Clamp(m_currentHealth -= amount, 0, m_maxHealth);
		health_bar.fillAmount = m_currentHealth / m_maxHealth;

		OnHealthChanged.Invoke(m_currentHealth, m_maxHealth);

		if (m_currentHealth <= 0)
		{
			OnDeath();
		}
	}

	[PunRPC]
	private void ApplyHealthInternal(float amount)
	{
		m_currentHealth = Mathf.Clamp(m_currentHealth += amount, 0, m_maxHealth);
		health_bar.fillAmount = m_currentHealth / m_maxHealth;

		OnHealthChanged.Invoke(m_currentHealth, m_maxHealth);
	}

	private void OnDeath()
	{
		
		Debug.Log($"{gameObject.name} / {PV.Owner.NickName} Died");
		player_Manager_Photon_Script.Die();
	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(m_currentHealth);
		}
		else
		{
			m_currentHealth = (float)stream.ReceiveNext();
			OnHealthChanged.Invoke(m_currentHealth, m_maxHealth);
		}
	}
}
