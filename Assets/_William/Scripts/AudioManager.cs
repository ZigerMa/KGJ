using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    AudioSource oneShotAudioPlayer;
    //AudioSource backgroundAudioPlayer;
    //AudioSource SkillClipAudioPlayer;
    //AudioSource loopClipAudioPlayer;

    [SerializeField] List<AudioClip> audioSoundClipList = new List<AudioClip>();
    //[SerializeField] List<AudioClip> audioMusicClipList = new List<AudioClip>();

    float oneShotAudioVolume = 1;

    //float backgroundAudipVolume = 1;
    //float loopClipAudipVolume = 1;
    //bool stillInTransitions = false;
    //TweenVolume tweenVolume;

    void Awake()
    {
        //Debug.Log("Audio Manager");

        oneShotAudioPlayer = gameObject.AddComponent<AudioSource>();
        oneShotAudioPlayer.playOnAwake = false;
        oneShotAudioPlayer.loop = false;
        oneShotAudioPlayer.rolloffMode = AudioRolloffMode.Linear;

        /*
        backgroundAudioPlayer = gameObject.AddComponent<AudioSource>();
        backgroundAudioPlayer.playOnAwake = false;
        backgroundAudioPlayer.loop = false;
        backgroundAudioPlayer.rolloffMode = AudioRolloffMode.Linear;

        SkillClipAudioPlayer = gameObject.AddComponent<AudioSource>();
        SkillClipAudioPlayer.playOnAwake = false;
        SkillClipAudioPlayer.loop = false;
        SkillClipAudioPlayer.rolloffMode = AudioRolloffMode.Linear;


        loopClipAudioPlayer = gameObject.AddComponent<AudioSource>();
        loopClipAudioPlayer.playOnAwake = false;
        loopClipAudioPlayer.loop = false;
        loopClipAudioPlayer.rolloffMode = AudioRolloffMode.Linear;

        tweenVolume = gameObject.AddComponent<TweenVolume>();
        tweenVolume.duration = 1;
        EventDelegate.Add(tweenVolume.onFinished, () => { tweenVolume.enabled = false; });
        tweenVolume.enabled = false;
        */

        AudioClip[] acSoundArray = Resources.LoadAll<AudioClip>("Sounds/");
        if (acSoundArray != null)
        {
            //Debug.Log("讀取音效");
            foreach (AudioClip ac in acSoundArray)
            {
                audioSoundClipList.Add(ac);
            }
        }
        else
        {
            Debug.LogError("Sounds沒有檔案");
        }

        /*
        AudioClip[] acMusicArray = Resources.LoadAll<AudioClip>("Musics/");
        if (acMusicArray != null) {
            //Debug.Log("讀取音樂");
            foreach (AudioClip ac in acMusicArray) {
                audioMusicClipList.Add(ac);
            }
        } else {
            Debug.LogError("Musics沒有檔案");
        }
        */
    }

    void Start()
    {

    }

    public void SetOneShotVolume(float volume)
    {
        oneShotAudioVolume = volume;
        oneShotAudioPlayer.volume = oneShotAudioVolume;
    }

    /*
    public void SetBackgroundVolume(float volume)
    {
        backgroundAudipVolume = volume;
        backgroundAudioPlayer.volume = backgroundAudipVolume;
    }
    
    public void SetLoopClipVolume(float volume)
    {
        loopClipAudipVolume = volume;
        loopClipAudioPlayer.volume = loopClipAudipVolume;
    }

    public void PlayBackgroundClip(string clipName)
    {
        //Debug.Log("PlayBackgroundClip====="+ clipName);
        if (!stillInTransitions)
        {
            StartCoroutine(TweenLastClip(clipName));
        }
    }
    */

    public void PlayOneShot(string clipName)
    {
        oneShotAudioPlayer.Stop();
        oneShotAudioPlayer.PlayOneShot(FindClipInBackgroundSoundList(clipName));
    }

    /*
    public void PlaySkillClip(string clipName)
    {
        SkillClipAudioPlayer.Stop();
        SkillClipAudioPlayer.PlayOneShot(FindClipInBackgroundSoundList(clipName));
    }


    public void PlayLoopClip(string clipName)
    {
        loopClipAudioPlayer.Stop();
        loopClipAudioPlayer.clip = FindClipInBackgroundSoundList(clipName);
        loopClipAudioPlayer.loop = true;
        loopClipAudioPlayer.Play();
    }

    public void PauseLoopClip()
    {
        loopClipAudioPlayer.Pause();
    }

    public void ResumeLoopClip()
    {
        loopClipAudioPlayer.UnPause();
    }

    public void StopLoopClip()
    {
        loopClipAudioPlayer.Stop();
    }
    
    public void StopBackgroundClip()
    {
        backgroundAudioPlayer.Stop();
    }
    */

    AudioClip FindClipInBackgroundSoundList(string clipName)
    {
        AudioClip returnAC = null;
        foreach (AudioClip ac in audioSoundClipList)
        {
            if (ac.name.Equals(clipName))
            {
                returnAC = ac;
                break;
            }
        }
        if (returnAC == null)
        {
            Debug.LogError("沒有正確的音效檔案 : " + clipName);
        }
        return returnAC;
    }

    /*
    AudioClip FindClipInBackgroundMusicList(string clipName)
    {
        AudioClip returnAC = null;
        foreach (AudioClip ac in audioMusicClipList)
        {
            if (ac.name.Equals(clipName))
            {
                returnAC = ac;
                break;
            }
        }
        if (returnAC == null)
        {
            Debug.LogError("沒有正確的音樂檔案 : " + clipName);
        }
        return returnAC;
    }

    IEnumerator TweenLastClip(string clipName)
    {
        stillInTransitions = true;
        if (backgroundAudioPlayer.clip != null)
        {
            //Debug.Log("前一首淡出");
            tweenVolume.from = 1.0f;
            tweenVolume.to = 0.1f;
            tweenVolume.enabled = true;
            tweenVolume.PlayForward();
        }
        yield return new WaitUntil(() => !tweenVolume.isActiveAndEnabled);
        //Debug.Log("tweenVolume結束");
        backgroundAudioPlayer.Stop();
        backgroundAudioPlayer.clip = FindClipInBackgroundMusicList(clipName);
        backgroundAudioPlayer.loop = true;
        backgroundAudioPlayer.volume = 0.1f;
        //tweenVolume.from = 0.1f;
        //tweenVolume.to = 1.0f;
        tweenVolume.enabled = true;
        backgroundAudioPlayer.Play();
        //Debug.Log("現在這首淡入");
        tweenVolume.PlayReverse();
        stillInTransitions = false;
    }
    */
}
