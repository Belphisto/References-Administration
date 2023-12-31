PGDMP     #                    {            References_Administration    15.3    15.3 C    N           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            O           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            P           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            Q           1262    16398    References_Administration    DATABASE     �   CREATE DATABASE "References_Administration" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
 +   DROP DATABASE "References_Administration";
                postgres    false            �            1259    16424    client    TABLE        CREATE TABLE public.client (
    id integer NOT NULL,
    fullname character varying(255) NOT NULL,
    login character varying(100) NOT NULL,
    password_hash character varying(255) NOT NULL,
    id_department integer,
    email character varying(30)
);
    DROP TABLE public.client;
       public         heap    postgres    false            �            1259    16423    client_id_seq    SEQUENCE     �   CREATE SEQUENCE public.client_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.client_id_seq;
       public          postgres    false    217            R           0    0    client_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.client_id_seq OWNED BY public.client.id;
          public          postgres    false    216            �            1259    16412 
   department    TABLE     }   CREATE TABLE public.department (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    parent_id integer
);
    DROP TABLE public.department;
       public         heap    postgres    false            �            1259    16411    department_id_seq    SEQUENCE     �   CREATE SEQUENCE public.department_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.department_id_seq;
       public          postgres    false    215            S           0    0    department_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.department_id_seq OWNED BY public.department.id;
          public          postgres    false    214            �            1259    16468    department_meetingroom    TABLE     v   CREATE TABLE public.department_meetingroom (
    departmentid integer NOT NULL,
    meetingroomid integer NOT NULL
);
 *   DROP TABLE public.department_meetingroom;
       public         heap    postgres    false            �            1259    16556 	   equipment    TABLE     �   CREATE TABLE public.equipment (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    meetingroomid integer NOT NULL
);
    DROP TABLE public.equipment;
       public         heap    postgres    false            �            1259    16555    equipment_id_seq    SEQUENCE     �   CREATE SEQUENCE public.equipment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.equipment_id_seq;
       public          postgres    false    227            T           0    0    equipment_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.equipment_id_seq OWNED BY public.equipment.id;
          public          postgres    false    226            �            1259    16496    event    TABLE     d  CREATE TABLE public.event (
    id integer NOT NULL,
    note character varying(255) NOT NULL,
    comment character varying(255),
    meetingroomid integer NOT NULL,
    startdate timestamp without time zone NOT NULL,
    enddate timestamp without time zone NOT NULL,
    status character varying(255) NOT NULL,
    client_login character varying(100)
);
    DROP TABLE public.event;
       public         heap    postgres    false            �            1259    16568    event_equipment    TABLE     j   CREATE TABLE public.event_equipment (
    event_id integer NOT NULL,
    equipment_id integer NOT NULL
);
 #   DROP TABLE public.event_equipment;
       public         heap    postgres    false            �            1259    16495    event_id_seq    SEQUENCE     �   CREATE SEQUENCE public.event_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.event_id_seq;
       public          postgres    false    224            U           0    0    event_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.event_id_seq OWNED BY public.event.id;
          public          postgres    false    223            �            1259    16462    meetingroom    TABLE     g   CREATE TABLE public.meetingroom (
    id integer NOT NULL,
    name character varying(255) NOT NULL
);
    DROP TABLE public.meetingroom;
       public         heap    postgres    false            �            1259    16461    meetingroom_id_seq    SEQUENCE     �   CREATE SEQUENCE public.meetingroom_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.meetingroom_id_seq;
       public          postgres    false    221            V           0    0    meetingroom_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.meetingroom_id_seq OWNED BY public.meetingroom.id;
          public          postgres    false    220            �            1259    16440    role    TABLE     _   CREATE TABLE public.role (
    id integer NOT NULL,
    name character varying(50) NOT NULL
);
    DROP TABLE public.role;
       public         heap    postgres    false            �            1259    16439    role_id_seq    SEQUENCE     �   CREATE SEQUENCE public.role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 "   DROP SEQUENCE public.role_id_seq;
       public          postgres    false    219            W           0    0    role_id_seq    SEQUENCE OWNED BY     ;   ALTER SEQUENCE public.role_id_seq OWNED BY public.role.id;
          public          postgres    false    218            �            1259    16511    userrole    TABLE     [   CREATE TABLE public.userrole (
    userid integer NOT NULL,
    roleid integer NOT NULL
);
    DROP TABLE public.userrole;
       public         heap    postgres    false            �           2604    16427 	   client id    DEFAULT     f   ALTER TABLE ONLY public.client ALTER COLUMN id SET DEFAULT nextval('public.client_id_seq'::regclass);
 8   ALTER TABLE public.client ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    217    217            �           2604    16415    department id    DEFAULT     n   ALTER TABLE ONLY public.department ALTER COLUMN id SET DEFAULT nextval('public.department_id_seq'::regclass);
 <   ALTER TABLE public.department ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    214    215    215            �           2604    16559    equipment id    DEFAULT     l   ALTER TABLE ONLY public.equipment ALTER COLUMN id SET DEFAULT nextval('public.equipment_id_seq'::regclass);
 ;   ALTER TABLE public.equipment ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    226    227    227            �           2604    16499    event id    DEFAULT     d   ALTER TABLE ONLY public.event ALTER COLUMN id SET DEFAULT nextval('public.event_id_seq'::regclass);
 7   ALTER TABLE public.event ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    223    224    224            �           2604    16465    meetingroom id    DEFAULT     p   ALTER TABLE ONLY public.meetingroom ALTER COLUMN id SET DEFAULT nextval('public.meetingroom_id_seq'::regclass);
 =   ALTER TABLE public.meetingroom ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    221    221            �           2604    16443    role id    DEFAULT     b   ALTER TABLE ONLY public.role ALTER COLUMN id SET DEFAULT nextval('public.role_id_seq'::regclass);
 6   ALTER TABLE public.role ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    218    219            @          0    16424    client 
   TABLE DATA           Z   COPY public.client (id, fullname, login, password_hash, id_department, email) FROM stdin;
    public          postgres    false    217   cM       >          0    16412 
   department 
   TABLE DATA           9   COPY public.department (id, name, parent_id) FROM stdin;
    public          postgres    false    215   �N       E          0    16468    department_meetingroom 
   TABLE DATA           M   COPY public.department_meetingroom (departmentid, meetingroomid) FROM stdin;
    public          postgres    false    222   xO       J          0    16556 	   equipment 
   TABLE DATA           <   COPY public.equipment (id, name, meetingroomid) FROM stdin;
    public          postgres    false    227   �O       G          0    16496    event 
   TABLE DATA           k   COPY public.event (id, note, comment, meetingroomid, startdate, enddate, status, client_login) FROM stdin;
    public          postgres    false    224   �O       K          0    16568    event_equipment 
   TABLE DATA           A   COPY public.event_equipment (event_id, equipment_id) FROM stdin;
    public          postgres    false    228   �R       D          0    16462    meetingroom 
   TABLE DATA           /   COPY public.meetingroom (id, name) FROM stdin;
    public          postgres    false    221   RS       B          0    16440    role 
   TABLE DATA           (   COPY public.role (id, name) FROM stdin;
    public          postgres    false    219   �S       H          0    16511    userrole 
   TABLE DATA           2   COPY public.userrole (userid, roleid) FROM stdin;
    public          postgres    false    225   �S       X           0    0    client_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.client_id_seq', 19, true);
          public          postgres    false    216            Y           0    0    department_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.department_id_seq', 13, true);
          public          postgres    false    214            Z           0    0    equipment_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.equipment_id_seq', 14, true);
          public          postgres    false    226            [           0    0    event_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.event_id_seq', 28, true);
          public          postgres    false    223            \           0    0    meetingroom_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.meetingroom_id_seq', 11, true);
          public          postgres    false    220            ]           0    0    role_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.role_id_seq', 14, true);
          public          postgres    false    218            �           2606    16433    client client_login_key 
   CONSTRAINT     S   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_login_key UNIQUE (login);
 A   ALTER TABLE ONLY public.client DROP CONSTRAINT client_login_key;
       public            postgres    false    217            �           2606    16431    client client_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.client DROP CONSTRAINT client_pkey;
       public            postgres    false    217            �           2606    16472 2   department_meetingroom department_meetingroom_pkey 
   CONSTRAINT     �   ALTER TABLE ONLY public.department_meetingroom
    ADD CONSTRAINT department_meetingroom_pkey PRIMARY KEY (departmentid, meetingroomid);
 \   ALTER TABLE ONLY public.department_meetingroom DROP CONSTRAINT department_meetingroom_pkey;
       public            postgres    false    222    222            �           2606    16417    department department_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.department DROP CONSTRAINT department_pkey;
       public            postgres    false    215            �           2606    16561    equipment equipment_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.equipment
    ADD CONSTRAINT equipment_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.equipment DROP CONSTRAINT equipment_pkey;
       public            postgres    false    227            �           2606    16503    event event_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.event
    ADD CONSTRAINT event_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.event DROP CONSTRAINT event_pkey;
       public            postgres    false    224            �           2606    16467    meetingroom meetingroom_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.meetingroom
    ADD CONSTRAINT meetingroom_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY public.meetingroom DROP CONSTRAINT meetingroom_pkey;
       public            postgres    false    221            �           2606    16510    role role_name_key 
   CONSTRAINT     M   ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_name_key UNIQUE (name);
 <   ALTER TABLE ONLY public.role DROP CONSTRAINT role_name_key;
       public            postgres    false    219            �           2606    16445    role role_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY public.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY public.role DROP CONSTRAINT role_pkey;
       public            postgres    false    219            �           2606    16515    userrole userrole_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.userrole
    ADD CONSTRAINT userrole_pkey PRIMARY KEY (userid, roleid);
 @   ALTER TABLE ONLY public.userrole DROP CONSTRAINT userrole_pkey;
       public            postgres    false    225    225            �           2606    16434     client client_id_department_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.client
    ADD CONSTRAINT client_id_department_fkey FOREIGN KEY (id_department) REFERENCES public.department(id);
 J   ALTER TABLE ONLY public.client DROP CONSTRAINT client_id_department_fkey;
       public          postgres    false    217    3217    215            �           2606    16473 ?   department_meetingroom department_meetingroom_departmentid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.department_meetingroom
    ADD CONSTRAINT department_meetingroom_departmentid_fkey FOREIGN KEY (departmentid) REFERENCES public.department(id);
 i   ALTER TABLE ONLY public.department_meetingroom DROP CONSTRAINT department_meetingroom_departmentid_fkey;
       public          postgres    false    3217    222    215            �           2606    16478 @   department_meetingroom department_meetingroom_meetingroomid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.department_meetingroom
    ADD CONSTRAINT department_meetingroom_meetingroomid_fkey FOREIGN KEY (meetingroomid) REFERENCES public.meetingroom(id);
 j   ALTER TABLE ONLY public.department_meetingroom DROP CONSTRAINT department_meetingroom_meetingroomid_fkey;
       public          postgres    false    3227    221    222            �           2606    16418 !   department department_parent_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.department
    ADD CONSTRAINT department_parent_fkey FOREIGN KEY (parent_id) REFERENCES public.department(id);
 K   ALTER TABLE ONLY public.department DROP CONSTRAINT department_parent_fkey;
       public          postgres    false    215    3217    215            �           2606    16562 &   equipment equipment_meetingroomid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.equipment
    ADD CONSTRAINT equipment_meetingroomid_fkey FOREIGN KEY (meetingroomid) REFERENCES public.meetingroom(id);
 P   ALTER TABLE ONLY public.equipment DROP CONSTRAINT equipment_meetingroomid_fkey;
       public          postgres    false    227    221    3227            �           2606    16579 1   event_equipment event_equipment_equipment_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.event_equipment
    ADD CONSTRAINT event_equipment_equipment_id_fkey FOREIGN KEY (equipment_id) REFERENCES public.equipment(id);
 [   ALTER TABLE ONLY public.event_equipment DROP CONSTRAINT event_equipment_equipment_id_fkey;
       public          postgres    false    3235    227    228            �           2606    16574 -   event_equipment event_equipment_event_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.event_equipment
    ADD CONSTRAINT event_equipment_event_id_fkey FOREIGN KEY (event_id) REFERENCES public.event(id);
 W   ALTER TABLE ONLY public.event_equipment DROP CONSTRAINT event_equipment_event_id_fkey;
       public          postgres    false    228    3231    224            �           2606    16504    event event_meetingroomid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.event
    ADD CONSTRAINT event_meetingroomid_fkey FOREIGN KEY (meetingroomid) REFERENCES public.meetingroom(id);
 H   ALTER TABLE ONLY public.event DROP CONSTRAINT event_meetingroomid_fkey;
       public          postgres    false    221    3227    224            �           2606    16590    event fk_client_login    FK CONSTRAINT     }   ALTER TABLE ONLY public.event
    ADD CONSTRAINT fk_client_login FOREIGN KEY (client_login) REFERENCES public.client(login);
 ?   ALTER TABLE ONLY public.event DROP CONSTRAINT fk_client_login;
       public          postgres    false    3219    224    217            �           2606    16521    userrole userrole_roleid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.userrole
    ADD CONSTRAINT userrole_roleid_fkey FOREIGN KEY (roleid) REFERENCES public.role(id) ON DELETE CASCADE;
 G   ALTER TABLE ONLY public.userrole DROP CONSTRAINT userrole_roleid_fkey;
       public          postgres    false    225    3225    219            �           2606    16516    userrole userrole_userid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.userrole
    ADD CONSTRAINT userrole_userid_fkey FOREIGN KEY (userid) REFERENCES public.client(id) ON DELETE CASCADE;
 G   ALTER TABLE ONLY public.userrole DROP CONSTRAINT userrole_userid_fkey;
       public          postgres    false    225    3221    217            @   /  x�}�=N�1�����/;��'�)X:0T*����8'@��
(gHoD�V�N����{�H�?����������RiN�"���y�T(�h��Ŋs*U<0��j* H��r��O�����z{~5_,�����O������s��?����b�R��rpl�I�U����E� ��������+�j#�#���G���Zc
�X��Q�cl�(j��Tm!HP�B���B(Yb�������k��w=���v�ppjr�Xm!� �ȷV�x�sI�<eT�\�5�%�7���&����i6�� ���
      >   �   x�uN�
A>�<��������r�Em)�v%K���Im6��
���fru�f��_�@�W4��1	G0C!�pc��Wd
<�!哰D���Q��o��1�c5&��Hi���)b��E�!K��hn��������"�!n���hZ��2��
KUg�q�kr� +���zPs=�w�ݞ�qڎY��K)�u��      E      x���44��44����� \      J   P   x�34估��֋��.컰�¾��/l�7]�pa��*rp���Ҙ��@��\�&D�5������ �eG      G   �  x��VKn�0]K��"p8�H�v�M��5�Ӡ�@����(�@�� =�k�M '��uH����D���7�{o�䐪����.�ZW�4<��g����ڮ�����3�{Lﱶ��Hi��A �HB؅�/�>�><��KYدD9%�;�_���yjR��e�n�>�U�������U��o����m0�'#D͔�\�P���ۣW��t�t19>��L�T �IO�5����.�f�G��{��}L<F��r8
�TK���g�.ܹ/Re�"���&a��A+͚$�]��k�ܓ��yIdO��>Ѐ2jd(AC�B}?I�b�P'ᵽ����G�7^�~>���;�o�F�fz\!��2R���iD�.��[�і0X҆a�a�r^DދgD�������[:#�8#�7BS�A���匨�6�FZ�"�D�rFt�H;��L��;j�b�G��|4�����'�	�LD,������������p�`2bvN]�����<(	�)&#�S�O/�g91p*C=��Ɉ�8�������sޏ1��z� ��qb�)�>e�7�LF,�)"�r���B�Ɉ�8e���ܵ�D�=�Ɉ�8w6��d�Vov�xܼ�~�][��;������,�d�z���:ց��]��2�"陻Ht���� &��XN������4=��$E��y��)�C�ٙ��"��pǣF���S�D:&���د˲�ԙ��      K   g   x�ϱ�0��(��?�Ջ����%?hpT���S���P��=�{8���z룏n��җ�x���>��-la��h扳���]�b������.v���߫��t�#�      D   1   x�34༰��֋��.컰�b���
�_�pa7��!.)#�=... r'"j      B   O   x�3�0�{.츰����.6\�p��¾�\f�]�z�$ua�������	��_�� s���=... �].�      H      x�34�4�2� ��&\1z\\\ ��     